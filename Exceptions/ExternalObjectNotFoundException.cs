using System;

namespace HobbyApp.Exceptions {
    public class ExternalObjectNotFoundException : Exception {
        public string Details { get; }

        public ExternalObjectNotFoundException(string message) : base(message) {

        }

        public ExternalObjectNotFoundException(string message, string details) : base(message) {
            this.Details = details;
        }
    }
}