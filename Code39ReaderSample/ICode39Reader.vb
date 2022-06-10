<Guid("A22222CC-1C19-416B-87D3-51A677C3CDF8")>
<InterfaceType(ComInterfaceType.InterfaceIsDual)>
Public Interface ICode39Reader
    ReadOnly Property Options As IReaderOptions
    Function ReadFromFile(filePath As String) As <MarshalAs(UnmanagedType.SafeArray)> String()
End Interface
