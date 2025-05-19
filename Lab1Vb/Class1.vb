Imports Lab1Cl

Namespace Lab1
    Public Class ClsCompliantVb
        Implements IClsCompliant

        Public Function Average(data As Integer()) As Integer Implements IClsCompliant.Average
            Return CType(data.Average(), Integer)
        End Function

        Public Function Merge(data As Char()) As String Implements IClsCompliant.Merge
            Return New String(data)
        End Function
    End Class
End Namespace