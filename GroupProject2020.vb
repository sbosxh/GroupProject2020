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

Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class FrmOrganizations
    Private Organizations1() As Hunger
    Private Organizations2() As Poverty
    Private nIndividual As Integer
    Private Type1 As Integer
    Private nDays As Integer
    Private Type2 As Integer
    Private count1 As Integer = 2
    Private count2 As Integer = 2

    'File information
    Private FS As FileStream
    Private ReadOnly Filename As String = "GroupProject2020.txt"
    Private BF As BinaryFormatter


    Private Sub BtnCreateFile_Click(sender As Object, e As EventArgs) Handles BtnCreateFile.Click   'creating a filestream here
        FS = New FileStream(Filename, FileMode.Create, FileAccess.Write)
        BF = New BinaryFormatter()

        FS.Close()
    End Sub

    Private Sub BtnSaveFile_Click(sender As Object, e As EventArgs) Handles BtnSaveFile.Click   'saving to file
        FS = New FileStream(Filename, FileMode.Open, FileAccess.ReadWrite)
        BF = New BinaryFormatter()



        FS.Close()
    End Sub
    'Enumeration
    Enum Organizations
        Hunger = 1
        Poverty = 2
    End Enum
    Enum Doners
        Individual = 1
        Organisation = 2
    End Enum


    Private Sub BtnSetUp_Click(sender As Object, e As EventArgs) Handles BtnSetUp.Click
        nIndividual += 1     'will go through each client 1 by 1

        ReDim Preserve Organizations1(count1)
        ReDim Preserve Organizations2(count2)


        Type2 = CInt(InputBox("Are you a: " & Environment.NewLine & "1) Individual " & Environment.NewLine & "2) Organization"))

        Select Case Type2     'For whether an organization or individual
            Case Doners.Individual

                Dim individualname As String
                individualname = InputBox("What is the name of the individual?")

                Type1 = CInt(InputBox("Which type of Organization are you choosing to donate to?" _
                                     & Environment.NewLine & "1)Hunger" & Environment.NewLine & "2)Poverty"))

                Select Case Type1     'which type are you donating to

                    Case Organizations.Hunger
                        Dim choice As Integer
                        For a As Integer = 1 To count1
                            Organizations1(a) = New Hunger(individualname, nIndividual)
                        Next a
                        Dim which As Integer = CInt(InputBox("Which organisation would you like to donate to?" _
                                                             + Environment.NewLine + "1) Bread for the world institute" _
                                                             + Environment.NewLine + "2) The hunger project" + Environment.NewLine + Store1()))


                        choice = CInt(InputBox("Would you like to donate: " + Environment.NewLine + "1) Food" + Environment.NewLine + "2) Money"))
                        If choice = 1 Then
                            Organizations1(which).Food = InputBox("What is the food you would like to donate?")
                            Organizations1(which).Calories = CInt(InputBox("How much calory does the product contain?"))
                            Organizations1(which).Caloriesfromfat = CInt(InputBox("How much calories from fat does the product contain?"))
                        End If
                        If choice = 2 Then
                            Organizations1(which).Amount(nIndividual) = CDbl(InputBox("How much money would you like to donate to the organisation?"))
                        End If
                        TxtDisplay.Text &= Organizations1(which).Display2() + Environment.NewLine
                       ' TxtDisplay.Text &= "Amount of fat in the product is " & Format(hungerr.CalcFat(), "0.00") & " units"
                    Case Organizations.Poverty
                        For x As Integer = 1 To count2
                            Organizations2(x) = New Poverty(individualname, nIndividual)
                        Next x
                        Dim which As Integer = CInt(InputBox("Which organisation would you like to donate to?" + Environment.NewLine + "1) Oxfam International" _
                                                             + Environment.NewLine + "2) Concern Worldwide" + Environment.NewLine + Store2()))
                        Organizations2(which).Amount(nIndividual) = CDbl(InputBox("How much would you like to donate towards fighting poverty?"))          'i realized that the maxamount() function won't work as the values will be mixed up unless we use a 2D array somehow
                        TxtDisplay.Text &= Organizations2(which).Display2() + Environment.NewLine
                End Select

            Case Doners.Organisation   'if they choose option 2,, organization
                Dim Organizationname As String = InputBox("What is the name of the Organisation?")
                Type1 = CInt(InputBox("Which type of Organization are you trying to create?" _
                                     & Environment.NewLine & "1)Hunger" & Environment.NewLine & "2)Poverty"))


                If Type1 = 1 Then
                    count1 += 1
                    ReDim Preserve Organizations1(count1)
                    Organizations1(count1) = New Hunger(Organizationname)  'i thought the numclients should be set to zero as it is not a client
                    Organizations1(count1).OrgName = Organizationname
                    Organizations1(count1).Country = InputBox("Which country would you like to help?")
                    Organizations1(count1).Population = CInt(InputBox("What is the population of the country you are trying to help?"))
                    Organizations1(count1).Deaths = CInt(InputBox("How many people on average are dying from hunger in " + Organizations1(count1).Country + "?"))
                    Dim acceptance As Integer = CInt(InputBox(Organizations1(count1).OrganisationAcceptance() _
                                                              + Environment.NewLine + "Have you been accepted?" _
                                                              + Environment.NewLine + "1) Yes" + Environment.NewLine + "2) No"))

                    If acceptance = 1 Then
                        Organizations1(count1).FinancialGoal = CDbl(InputBox("How much do you aim to raise towards fighting hunger in " + Organizations1(count1).Country + "?"))
                        TxtDisplay.Text &= Organizations1(count1).Display() + Environment.NewLine
                    Else
                        count1 -= 1
                        ReDim Preserve Organizations1(count1)
                    End If
                End If
                If Type1 = 2 Then
                    count2 += 1
                    ReDim Preserve Organizations2(count2)
                    Organizations2(count2) = New Poverty(Organizationname)
                    Organizations2(count2).OrgName = Organizationname
                    Organizations2(count2).Country = InputBox("Which country would you like to help?")
                    Organizations2(count2).Population = CInt(InputBox("What is the population of the country you are trying to help?"))
                    Organizations2(count2).Unemployed = CInt(InputBox("How many people on average are unemployed in " + Organizations2(count2).Country + "?"))
                    Dim acceptance As Integer = CInt(InputBox(Organizations2(count2).OrganisationAcceptance() _
                                                              + Environment.NewLine + "Have you been accepted?" _
                                                              + Environment.NewLine + "1) Yes" + Environment.NewLine + "2) No"))
                    If acceptance = 1 Then
                        Organizations2(count2).FinancialGoal = CDbl(InputBox("How much do you aim to raise towards fighting poverty in " + Organizations2(count2).Country + "?"))
                        TxtDisplay.Text &= Organizations2(count2).Display() + Environment.NewLine
                    Else
                        count2 -= 1
                        ReDim Preserve Organizations2(count2)
                    End If
                End If

        End Select


    End Sub


    Private Function Store1() As String    'for hunger
        Dim display As String = ""
        Dim count As Integer = 3
        While count <= Organizations2.Length - 1
            display &= CStr(count) + ") " + Organizations2(count).OrgName + Environment.NewLine
            count += 1
        End While
        Return display
    End Function

    Private Function Store2() As String    'for poverty
        Dim display As String = ""
        Dim count As Integer = 3
        While count <= Organizations2.Length - 1
            display &= CStr(count) + ") " + Organizations2(count).OrgName + Environment.NewLine
            count += 1
        End While
        Return display
    End Function