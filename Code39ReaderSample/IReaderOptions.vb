<Guid("1C840C56-8198-4260-8639-BEBBE8BF381E")>
<InterfaceType(ComInterfaceType.InterfaceIsDual)>
Public Interface IReaderOptions
    Property TryHarder As Boolean
    Property TryInverted As Boolean
    Property PureBarcode As Boolean
    Property CharacterSet As String
    Property UseCode39ExtendedMode As Boolean
    Property UseCode39RelaxedExtendedMode As Boolean
    Property AssumeCode39CheckDigit As Boolean
End Interface
