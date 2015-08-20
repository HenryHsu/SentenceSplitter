Public Class Segment
    Public Sub New()

    End Sub

    Public Sub New(_content As String)
        Me.Content = _content
    End Sub

    Public Property [Type] As SegmentType
    Public Property Content As String
End Class

Public Enum SegmentType
    SegmentableText = 0
    StructureText = 1
End Enum
