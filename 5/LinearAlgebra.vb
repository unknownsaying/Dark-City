' LinearAlgebra.vb - Core Concepts in <50 Lines
Public Class LinearAlgebra
    ' Vector Operations
    Public Shared Function Add(v1 As Double(), v2 As Double()) As Double()
        Return v1.Zip(v2, Function(a, b) a + b).ToArray()
    End Function

    Public Shared Function Dot(v1 As Double(), v2 As Double()) As Double
        Return v1.Zip(v2, Function(a, b) a * b).Sum()
    End Function

    ' Matrix Operations  
    Public Shared Function Multiply(A As Double(,), B As Double(,)) As Double(,)
        Dim rowsA = A.GetLength(0), colsA = A.GetLength(1), colsB = B.GetLength(1)
        Dim C(rowsA - 1, colsB - 1) As Double
        
        For i = 0 To rowsA - 1
            For j = 0 To colsB - 1
                For k = 0 To colsA - 1
                    C(i, j) += A(i, k) * B(k, j)
                Next
            Next
        Next
        Return C
    End Function

    ' Determinant (2x2 and 3x3)
    Public Shared Function Det2x2(A As Double(,)) As Double
        Return A(0,0)*A(1,1) - A(0,1)*A(1,0)
    End Function

    Public Shared Function Det3x3(A As Double(,)) As Double
        Return A(0,0)*(A(1,1)*A(2,2) - A(1,2)*A(2,1)) -
               A(0,1)*(A(1,0)*A(2,2) - A(1,2)*A(2,0)) +
               A(0,2)*(A(1,0)*A(2,1) - A(1,1)*A(2,0))
    End Function

    ' Linear System Solving (2x2 using Cramer's Rule)
    Public Shared Function Solve2x2(A As Double(,), b As Double()) As Double()
        Dim detA = Det2x2(A)
        If Math.Abs(detA) < 0.0001 Then Throw New Exception("Singular matrix")
        
        Dim A1 = {{b(0), A(0,1)}, {b(1), A(1,1)}}
        Dim A2 = {{A(0,0), b(0)}, {A(1,0), b(1)}}
        
        Return {Det2x2(A1)/detA, Det2x2(A2)/detA}
    End Function

    ' Eigenvalue approximation (Power Method for dominant eigenvalue)
    Public Shared Function PowerMethod(A As Double(,), iterations As Integer) As Double
        Dim v = Enumerable.Repeat(1.0, A.GetLength(0)).ToArray()
        For i = 1 To iterations
            v = MultiplyVectorMatrix(v, A)
            v = Normalize(v)
        Next
        Return RayleighQuotient(A, v)
    End Function

    Private Shared Function MultiplyVectorMatrix(v As Double(), A As Double(,)) As Double()
        Dim result(v.Length - 1) As Double
        For i = 0 To A.GetLength(0) - 1
            For j = 0 To A.GetLength(1) - 1
                result(i) += v(j) * A(i, j)
            Next
        Next
        Return result
    End Function

    Private Shared Function Normalize(v As Double()) As Double()
        Dim norm = Math.Sqrt(v.Sum(Function(x) x * x))
        Return v.Select(Function(x) x / norm).ToArray()
    End Function

    Private Shared Function RayleighQuotient(A As Double(,), v As Double()) As Double
        Dim Av = MultiplyVectorMatrix(v, A)
        Return Dot(v, Av) / Dot(v, v)
    End Function
End Class