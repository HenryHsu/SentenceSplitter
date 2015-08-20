Imports System.Text.RegularExpressions
Public Class SentenceSplitter
    Private Shared tokenize As New Regex("(\S{2,}[.!?:]+)[\p{Z}\r\n]+")
    Private Shared tokenize2 As New Regex("([。\r\n])")
    Private Shared tokenize3 As New Regex("([\u0E00-\u0E7F])(\p{Z}[\r\n])+([\u0E00-\u0E7F])")

    Public Shared Function GetSplitedSegments(srcText As String, tgtText As String, Optional ByVal srcLang As String = "en-US", Optional ByVal tgtLang As String = "") As String()()

        ' Split source and target segment into 2 arrays
        Dim srcSplited As New List(Of String)(10)
        Dim tgtSplited As New List(Of String)(10)
        srcLang = srcLang.ToLower()
        tgtLang = tgtLang.ToLower()


        Dim src2split As String = tokenize.Replace(srcText, "${1}@x@x@x@")
        Dim tgt2split As String = tokenize.Replace(tgtText, "${1}@x@x@x@")
        src2split = tokenize2.Replace(src2split, "${1}@x@x@x@")
        tgt2split = tokenize2.Replace(tgt2split, "${1}@x@x@x@")
        If srcLang.StartsWith("th") Or srcLang.StartsWith("zh") Then
            src2split = tokenize3.Replace(src2split, "${1}@x@x@x@${3}")
        End If
        If tgtLang.StartsWith("th") Or srcLang.StartsWith("zh") Then
            tgt2split = tokenize3.Replace(tgt2split, "${1}@x@x@x@${3}")
        End If

        Dim strSpliter As New Regex("@x@x@x@")
        srcSplited.Clear()
        tgtSplited.Clear()
        srcSplited.AddRange(strSpliter.Split(src2split))
        tgtSplited.AddRange(strSpliter.Split(tgt2split))

        ' Clean empty Segments
        For j As Integer = srcSplited.Count - 1 To 0 Step -1
            If srcSplited(j).Trim() = String.Empty Then
                srcSplited.RemoveAt(j)
            Else
                srcSplited(j) = srcSplited(j).Trim(vbCr, vbLf)
            End If
        Next

        For j As Integer = tgtSplited.Count - 1 To 0 Step -1
            If tgtSplited(j).Trim() = String.Empty Then
                tgtSplited.RemoveAt(j)
            Else
                tgtSplited(j) = tgtSplited(j).Trim(vbCr, vbLf)
            End If
        Next

        If srcSplited.Count = tgtSplited.Count Then
            Return New String()() {srcSplited.ToArray(), tgtSplited.ToArray()}
        Else
            Return New String()() {New String() {srcText}, New String() {tgtText}}
        End If
    End Function

    Public Shared Function GetSegmentsFromText(ByVal segmentText As String, Optional ByVal lang As String = "en-us") As List(Of Segment)
        lang = lang.ToLower()
        Dim strSplited As New List(Of Segment)(10)
        Dim str2split As String
        str2split = tokenize.Replace(str2split, "${1}@x@x@x@")


    End Function
End Class
