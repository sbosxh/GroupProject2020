

'*************** Group Details ******************

'1. M Malim 
' Student Number: 220087951
'
'2. JL Mabaso 
' Student Number: 220003048
'
'3. ME Segoe 
' Student Number: 220034440
'
'4. T Kgatla 
' Student Number: 220012348
Option Strict On
Option Explicit On
Option Infer Off
Public Class Organization
    Implements IDonate

    '********************* Attributes **************************
    Private Shared _NextClient As Integer
    Private _OrgName As String
    Private _Level As Integer
    Private _NameofClient As String
    Private _Amount() As Double
    Private _TotalAmount As Double
    Protected _FinancialGoal As Double
    Private _Population As Integer
    Private _Country As String

    '************************** Constructor ********************
    Public Sub New(_NameofClient As String, numClients As Integer)
        Me._NameofClient = _NameofClient
        ReDim _Amount(numClients)
    End Sub
    '************************ Methods *************************
    Private Function NextC() As Integer   'utility method for used for shared
        _NextClient += 1
        Return _NextClient
    End Function
    Public Property Level As Integer
        Get
            Return _Level
        End Get
        Set(value As Integer)
            If value < 0 Then
                _Level = 0
            Else
                _Level = value
            End If
        End Set
    End Property

    Public Property Population() As Integer
        Set(value As Integer)
            _Population = value
        End Set
        Get
            Return _Population
        End Get
    End Property
    Public Property OrgName() As String
        Set(value As String)
            _OrgName = value
        End Set
        Get
            Return _OrgName
        End Get
    End Property
    Public Property Country() As String
        Set(value As String)
            _Country = value
        End Set
        Get
            Return _Country
        End Get
    End Property
    Public Property Amount(index As Integer) As Double
        Get
            Return _Amount(index)
        End Get
        Set(value As Double)
            _Amount(index) = value
        End Set
    End Property

    Public Overridable Function CalcTotAve() As Double   'finding the tot & average
        _TotalAmount = 0
        For a As Integer = 1 To _Amount.Length - 1
            _TotalAmount += _Amount(a)
        Next a
        Return _TotalAmount / (_Amount.Length - 1)
    End Function


    Public Function MaxAmount() As Double  'finding the maximum amount
        Dim Max As Double
        Max = _Amount(1)

        For x As Integer = 2 To _Amount.Length - 1
            If Max < _Amount(x) Then
                Max = _Amount(x)
            End If
        Next x
        Return Max
    End Function

    Public Overridable Function Display() As String  'For organization
        Return "Organization name: " & _OrgName & Environment.NewLine & "Country Name: " _
            & _Country & Environment.NewLine _
            & "Population " _
            & _Population & Environment.NewLine & "Total amount: " & _TotalAmount & Environment.NewLine & "/Financial goal: " & _FinancialGoal
    End Function

    Public Overridable Function Display2() As String  ''For Client
        For t As Integer = 1 To _Amount.Length - 1
            Return "Client: " & NextC() _
                & Environment.NewLine & "Client name: " _
                & _NameofClient & Environment.NewLine _
                & "Country Name: " & _Country & Environment.NewLine & "Amount donated: " & _Amount(t) & Environment.NewLine
        Next t
    End Function


    Public Overridable Function Levels() As Integer
        '''''''''''''''
    End Function
    Public Function OrganisationAcceptance() As String
        Dim Alert As String
        If Levels() > 0 Then
            Alert = "Your application has been accepted"
        Else
            Alert = "Your application has been rejected"
        End If
        Return Alert
    End Function

    Public Function GoalReached() As String Implements IDonate.GoalReached   'use of interface
        Dim Answer As String
        If _FinancialGoal >= _TotalAmount Then
            Answer = "Congratulations, the financial goal has been reached."
        Else
            Answer = "Sorry, the financial goal was not attained."
        End If
        Return Answer
    End Function