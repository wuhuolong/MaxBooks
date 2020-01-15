namespace xc
{
    /// <summary>
    /// Status of path.
    /// </summary>
    public enum XNavMeshPathStatus
    {
        /// <summary>
        /// The path terminates at the destination.
        /// </summary>
        PathComplete = 0,

        /// <summary>
        /// The path cannot reach the destination.
        /// </summary>
        PathPartial = 1,

        /// <summary>
        /// The path is invalid.
        /// </summary>
        PathInvalid = 2
    }
}
