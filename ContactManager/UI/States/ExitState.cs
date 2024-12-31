﻿namespace ContactManager.UI.States
{
    public class ExitState : IUIState
    {
        public Task Execute(IUIStateController controller, CancellationToken stoppingToken)
        {
            Console.WriteLine("Exiting...");
            controller.Stop();
            stoppingToken.WaitHandle.WaitOne();
            return Task.CompletedTask;
        }
    }
}
