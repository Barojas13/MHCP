using _5_Tesis.TransverseInfraestructure.Interfaces;

namespace _5_Tesis.TransverseInfraestructure.Implementations
{
    public class ObjectConverterHelper : IObjectConverterHelper
    {
        public TObjectReturn SetObjectProperties<TObjectBase, TObjectReturn>(TObjectBase objectBase, TObjectReturn objectReturn)
        {
            foreach (var property in objectBase.GetType().GetProperties())
            {
                if (property.CanRead)
                {
                    objectReturn.GetType().GetProperties().
                      FirstOrDefault(x => x.Name == property.Name).
                      SetValue(objectReturn, property.GetValue(objectBase, null));
                }
            }

            return objectReturn;
        }
    }
}
