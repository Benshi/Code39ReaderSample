Option Strict On

<Guid("1FA2E199-DC60-48E7-A08B-F6F17F4E0439")>
<ComVisible(True)>
<ClassInterface(ClassInterfaceType.None)>
<ComDefaultInterface(GetType(ICode39Reader))>
<ProgId("Orator.Code39Reader")>
Public Class Code39Reader
    Implements ICode39Reader
    Private ReadOnly reader As IBarcodeReader

    Public ReadOnly Property Options As IReaderOptions Implements ICode39Reader.Options
    Public Sub New()
        reader = New BarcodeReader()
        reader.Options.PossibleFormats = New BarcodeFormat(0) {BarcodeFormat.CODE_39}
        reader.Options.AssumeCode39CheckDigit = False
        reader.Options.TryHarder = True
        Options = New ReaderOptions(reader.Options)
    End Sub

    Public Function ReadFromFile(filePath As String) As <MarshalAs(UnmanagedType.SafeArray)> String() Implements ICode39Reader.ReadFromFile
        Dim codeList As New List(Of String)()
        DirectCast(Options, ReaderOptions).Fill(reader.Options)
        For Each bmp In GetBitmaps(filePath)
            Dim results = reader.DecodeMultiple(bmp)
            If results IsNot Nothing Then
                For Each result In results
                    If result.BarcodeFormat.HasFlag(BarcodeFormat.CODE_39) AndAlso Not String.IsNullOrEmpty(result.Text) Then
                        codeList.Add(result.Text)
                    End If
                Next
            End If
            bmp.Dispose()
        Next
        Return codeList.ToArray()
    End Function

    Private Function GetBitmaps(filePath As String) As Bitmap()
        If String.IsNullOrWhiteSpace(filePath) OrElse Not File.Exists(filePath) Then
            Return New Bitmap(-1) {}
        End If
        If Not filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) Then
            Try
                Return New Bitmap(0) {New Bitmap(filePath)}
            Catch
            End Try
        End If
        Dim bitmaps As New List(Of Bitmap)()
        Try
            Dim pdfBaseStream As New MemoryStream(File.ReadAllBytes(filePath))
            Using pdfStream = pdfBaseStream.AsRandomAccessStream()
                'Dim doc = PdfDocument.LoadFromStreamAsync(pdfStream).GetResults()
                Dim doc = PdfDocument.LoadFromStreamAsync(pdfStream).AsTask().Result
                For pageIndex = 0UI To doc.PageCount - 1UI
                    Using page = doc.GetPage(pageIndex)
                        Try
                            Dim memStream As New MemoryStream()
                            'page.RenderToStreamAsync(memStream.AsRandomAccessStream()).GetResults()
                            page.RenderToStreamAsync(memStream.AsRandomAccessStream()).AsTask().GetAwaiter().GetResult()
                            bitmaps.Add(New Bitmap(memStream))
                        Catch
                        End Try
                    End Using
                Next
            End Using
        Catch
        End Try
        Return bitmaps.ToArray()
    End Function
End Class
