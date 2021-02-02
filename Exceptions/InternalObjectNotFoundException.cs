using System;

namespace HobbyApp.Exceptions {
    public class InternalObjectNotFoundException : Exception {
        public string Details { get; }

        public InternalObjectNotFoundException(string message) : base(message) {

        }

        public InternalObjectNotFoundException(string message, string details) : base(message) {
            this.Details = details;
        }
    }
}