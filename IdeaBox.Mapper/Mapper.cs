
using IdeaBox.Mapper.Attributes;
using System.Reflection;

namespace IdeaBox.Mapper
{
    public class Mapper : IMapper
    {
        public object Map(object obj)
        {
            var sourceType = obj.GetType();

            Type? targetType = null;
            // Conditional mapping
            var condMapAtts = sourceType.GetCustomAttributes<ConditionalMapClassAttribute>();
            foreach (var condMapAtt in condMapAtts)
            {
                var expectedVal = condMapAtt.ConditionalValue;
                var condProperty = sourceType.GetProperty(condMapAtt.PropertyName);
                if (condProperty == null) throw new InvalidOperationException($"Type {condMapAtt.Type.Name} does not have property named {condMapAtt.PropertyName}.");

                
                var condVal = condProperty.GetValue(obj);
                if (condVal != null && condVal.GetType() != condProperty.PropertyType) throw new InvalidOperationException("Types of value and expected value do not match.");

                if (condVal?.Equals(condMapAtt.ConditionalValue) ?? condMapAtt.ConditionalValue == null)
                {
                    targetType = condMapAtt.Type;
                    break;
                }
            }

            // Default mapping
            if(targetType == null)
            {
                targetType = sourceType.GetCustomAttribute<MapClassAttribute>()?.Type;
                if (targetType == null) throw new InvalidOperationException($"Type {sourceType.Name} is not annotated with a {nameof(MapClassAttribute)} attribute.");
            }

            // Create res object
            var res = targetType.GetConstructor([])?.Invoke([]);
            if (res == null) throw new InvalidOperationException($"Type {targetType.Name} does not have an empty constructor.");

            // Set properties
            foreach (var sourceProp in obj.GetType().GetProperties())
            {
                var att = sourceProp.GetCustomAttribute<MapPropertyAttribute>();
                if (att == null) continue;

                var targetProp = targetType.GetProperty(att.Name);
                if (targetProp == null) throw new InvalidOperationException($"Type {targetType.Name} does not have a property named {att.Name}");

                object? subRes;
                if (att.IsNested)
                {
                    var sourceVal = sourceProp.GetValue(obj);
                    subRes = sourceVal == null ? null : Map(sourceVal);
                }
                else
                {
                    if (sourceProp.PropertyType != targetProp.PropertyType) throw new InvalidOperationException($"Type mismatch between property named {att.Name} of types {sourceType.Name} and {targetType.Name}");
                    subRes = sourceProp.GetValue(obj);
                }


                targetProp.SetValue(res, subRes);
            }

            return res;
        }
    }
}
