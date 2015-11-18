Imports Microsoft.Win32.TaskScheduler
Imports System.IO

Public Class Form1
    Public Shared Function ScheduleTaskInWin_TaskScheduler(
                                                          ByRef sunday As String, _
                                                          ByRef monday As String, _
                                                          ByRef tues As String, _
                                                          ByRef wedn As String, _
                                                          ByRef thursday As String, _
                                                          ByRef friday As String, _
                                                          ByRef saturday As String
                                                          )
        Using ts As New TaskService()
            ' Create a new task definition and assign properties
            Dim td As TaskDefinition = ts.NewTask
            td.RegistrationInfo.Description = _
              "Any description which you want to give for you task. "
            ' use below mentioned code for WeeklyTrigger 
            Dim wt As New WeeklyTrigger()
            wt.StartBoundary = DateTime.Today.AddDays(0)
            wt.DaysOfWeek = sunday Or monday Or tues Or wedn Or thursday Or friday Or saturday
            wt.Repetition.Duration = TimeSpan.FromHours(24)
            wt.Repetition.Interval = TimeSpan.FromDays(1)
            td.Triggers.Add(wt)

            ' use below mentioned code whin you want to create
            ' dailytrigger as in a way in each our after 1 hour

            'Dim dt As New DailyTrigger()
            'dt.DaysInterval = 1
            'dt.StartBoundary = DateTime.Today.AddDays(0)
            'dt.Repetition.Duration = TimeSpan.FromDays(30)
            'dt.Repetition.Interval = TimeSpan.FromMinutes(60)

            'td.Triggers.Add(dt)

<<<<<<< HEAD
<<<<<<< HEAD




            'only another change from DC


=======
>>>>>>> parent of d751599... part1 DC
=======
>>>>>>> parent of d751599... part1 DC

            Dim FolderPath As String = AppDomain.CurrentDomain.BaseDirectory
            Dim ExeLocation As String = Path.Combine(FolderPath, "nameOfExe.exe")
            ExeLocation = ExeLocation.Replace("\"c, "/"c)
            ' Add an action (shorthand) that runs Notepad
            td.Actions.Add(New ExecAction(ExeLocation, "c:\nameOfLogFile.log"))
            ' Register the task in the root folder
            ts.RootFolder.RegisterTaskDefinition("NameOfScheduleTask", td)
        End Using


        Return ""
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sunday As String = DaysOfTheWeek.Sunday
        Dim monday As String = DaysOfTheWeek.Monday
        Dim tuesday As String = DaysOfTheWeek.Tuesday
        Dim Wednesday As String = DaysOfTheWeek.Wednesday
        Dim Thursday As String = DaysOfTheWeek.Thursday
        Dim Friday As String = DaysOfTheWeek.Friday
        Dim Saturday As String = DaysOfTheWeek.Saturday

        ScheduleTaskInWin_TaskScheduler(sunday, monday, _
                 tuesday, Wednesday, Thursday, Friday, Saturday)
    End Sub
End Class