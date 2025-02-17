[System.Serializable]
public class OperationDeniedException : System.Exception
{
    public OperationDeniedException() { }

    public OperationDeniedException(string message)
        : base(message) { }

    public OperationDeniedException(string message, System.Exception inner)
        : base(message, inner) { }
}
