namespace _5_Tesis.TransverseInfraestructure.Interfaces
{
    public interface IObjectConverterHelper
    {
        TObjectReturn SetObjectProperties<TObjectBase, TObjectReturn>(TObjectBase objectBase, TObjectReturn objectReturn);
    }
}
