namespace BLL.Interfaces
{
    public interface IGenericService<in TModel>
    {
         Task SendNotification(TModel model);
    }
}
 