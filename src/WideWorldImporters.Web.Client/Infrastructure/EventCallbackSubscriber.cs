﻿// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Components;

namespace WideWorldImporters.Web.Client.Shared.Infrastructure
{
    public sealed class EventCallbackSubscriber<T> : IDisposable
    {
        private readonly EventCallback<T> _handler;
        private EventCallbackSubscribable<T>? _existingSubscription;

        public EventCallbackSubscriber(EventCallback<T> handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Creates a subscription on the <paramref name="subscribable"/>, or moves any existing subscription to it
        /// by first unsubscribing from the previous <see cref="EventCallbackSubscribable{T}"/>.
        ///
        /// If the supplied <paramref name="subscribable"/> is null, no new subscription will be created, but any
        /// existing one will still be unsubscribed.
        /// </summary>
        /// <param name="subscribable"></param>
        public void SubscribeOrMove(EventCallbackSubscribable<T>? subscribable)
        {
            if (subscribable != _existingSubscription)
            {
                _existingSubscription?.Unsubscribe(this);
                subscribable?.Subscribe(this, _handler);
                _existingSubscription = subscribable;
            }
        }

        public void Dispose()
        {
            _existingSubscription?.Unsubscribe(this);
        }
    }
}
