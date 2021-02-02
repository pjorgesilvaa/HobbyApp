using System;

namespace HobbyApp.Exceptions {
    public class BusinessRuleValidationException : Exception {
        public string Details { get; }

        public BusinessRuleValidationException() : base() {
        }

        public BusinessRuleValidationException(string message) : base(message) {
        }

        public BusinessRuleValidationException(string message, string details) : base(message) {
            this.Details = details;
        }
    }
}