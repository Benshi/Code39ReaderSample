<ComVisible(False)>
Public Class ReaderOptions
    Implements IReaderOptions
    Public Property TryHarder As Boolean Implements IReaderOptions.TryHarder
    Public Property TryInverted As Boolean Implements IReaderOptions.TryInverted
    Public Property PureBarcode As Boolean Implements IReaderOptions.PureBarcode
    Public Property CharacterSet As String Implements IReaderOptions.CharacterSet
    Public Property UseCode39ExtendedMode As Boolean Implements IReaderOptions.UseCode39ExtendedMode
    Public Property UseCode39RelaxedExtendedMode As Boolean Implements IReaderOptions.UseCode39RelaxedExtendedMode
    Public Property AssumeCode39CheckDigit As Boolean Implements IReaderOptions.AssumeCode39CheckDigit
    Public Sub New()
    End Sub
    Friend Sub New(o As DecodingOptions)
        TryHarder = o.TryHarder
        TryInverted = o.TryInverted
        AssumeCode39CheckDigit = o.AssumeCode39CheckDigit
        PureBarcode = o.PureBarcode
        CharacterSet = o.CharacterSet
        UseCode39ExtendedMode = o.UseCode39ExtendedMode
        UseCode39RelaxedExtendedMode = o.UseCode39RelaxedExtendedMode
    End Sub
    Friend Sub Fill(o As DecodingOptions)
        o.TryHarder = TryHarder
        o.TryInverted = TryInverted
        o.PureBarcode = PureBarcode
        o.CharacterSet = CharacterSet
        o.UseCode39ExtendedMode = UseCode39ExtendedMode
        o.UseCode39RelaxedExtendedMode = UseCode39RelaxedExtendedMode
        o.AssumeCode39CheckDigit = AssumeCode39CheckDigit
    End Sub
End Class
