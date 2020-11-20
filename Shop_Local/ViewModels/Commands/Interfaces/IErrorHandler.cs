using System;

namespace Shop_Local.ViewModels.Commands.Interfaces
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
