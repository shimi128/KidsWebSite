﻿namespace WebExtensions.Events
{
    public interface IConsumer<T>
    {
        void HandleEvent(T eventMessage);
    }
}