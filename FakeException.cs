namespace dotnet_polly
{
    [System.Serializable]
    public class FakeException : System.Exception
    {
        public FakeException() { }
        public FakeException(string message) : base(message) { }
        public FakeException(string message, System.Exception inner) : base(message, inner) { }
        protected FakeException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}