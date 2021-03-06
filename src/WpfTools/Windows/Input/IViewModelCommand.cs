﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Algel.WpfTools.Events;

namespace Algel.WpfTools.Windows.Input
{
    /// <summary>
    /// Defines a ViewModelCommand
    /// </summary>
    public interface IViewModelCommand : ICommand
    {
        event EventHandler<DataEventArgs> CommandExecuted;
        event EventHandler<CancelDataEventArgs> CommandExecuting;

        void Execute();

        Task ExecuteAsync();
        Task ExecuteAsync(object arg);
        void RaiseCanExecuteChanged();
        bool CanExecute();
        bool IsExecuting { get; }
        bool IsAsync { get; }
    }
}
