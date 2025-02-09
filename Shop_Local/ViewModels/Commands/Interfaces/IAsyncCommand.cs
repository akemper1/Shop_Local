﻿using System.Threading.Tasks;
using System.Windows.Input;

namespace Shop_Local.ViewModels.Commands.Interfaces
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();

        bool CanExecute();

        public interface IAsyncCommand<T> : ICommand
        {
            Task ExecuteAsync(T parameter);
            bool CanExecute(T parameter);
        }
    }
}
