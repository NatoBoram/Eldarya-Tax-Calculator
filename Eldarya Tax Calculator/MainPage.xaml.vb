' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports Windows.UI
Imports Windows.System
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
	Inherits Page

#Region "Calculator"

	Private Function Minus5Percent(maana As Double) As Double
		Return maana * 100 / 105
	End Function

	Private Function Plus5Percent(maana As Double) As Double
		Return maana * 105 / 100
	End Function

	Private Function MaanaToCAD(maana As Double) As Double
		Return maana * 5 / 500
	End Function

	Private Function MaanaToEUR(maana As Double) As Double
		Return maana * 5 / 750
	End Function

	Private Function GoldToCAD(gold As Double) As Double
		Return gold * 5 / 165
	End Function

	Private Function GoldToEUR(gold As Double) As Double
		Return gold * 5 / 250
	End Function

	Private Function CADToMaana(cad As Double) As Double
		Return cad * 500 / 5
	End Function

	Private Function CADToGold(cad As Double) As Double
		Return cad * 165 / 5
	End Function

	Private Function EURToMaana(eur As Double) As Double
		Return eur * 750 / 5
	End Function

	Private Function EURToGold(eur As Double) As Double
		Return eur * 250 / 5
	End Function

	Private Function ShareMaana(maana As Double) As Double
		Return maana * 100 / (105 * 4)
	End Function

	Private Function UnshareMaana(maana As Double) As Double
		Return maana * 4 * 105 / 100
	End Function

#End Region

	Private Sub TextChanged(sender As TextBox, e As TextChangedEventArgs) Handles MaanasInput.TextChanged, MaanasMinusTaxes.TextChanged, MaanasPlusTaxes.TextChanged, SharedMaanas.TextChanged, GoldInput.TextChanged, DeviseCAD.TextChanged, DeviseEUR.TextChanged

		' Check for focus
		If sender.FocusState = FocusState.Unfocused Then Return

		' Check for double
		Dim amount As Double
		If Not Double.TryParse(sender.Text, amount) Then Return

		' Convert amount to maana
		Select Case sender.Name
			Case "MaanasInput"
				Dim maana As Double = amount
				' MaanasInput.Text = Math.Round(maana)
				MaanasMinusTaxes.Text = Math.Round(Minus5Percent(maana))
				MaanasPlusTaxes.Text = Math.Round(Plus5Percent(maana))
				SharedMaanas.Text = Math.Round(ShareMaana(maana))
				GoldInput.Text = Math.Round(MaanaToEUR(EURToGold(maana)))
				DeviseCAD.Text = Math.Round(MaanaToCAD(maana))
				DeviseEUR.Text = Math.Round(MaanaToEUR(maana))
			Case "MaanasMinusTaxes"
				Dim maana As Double = Plus5Percent(amount)
				MaanasInput.Text = Math.Round(maana)
				' MaanasMinusTaxes.Text = Math.Round(Minus5Percent(maana))
				MaanasPlusTaxes.Text = Math.Round(Plus5Percent(maana))
				SharedMaanas.Text = Math.Round(ShareMaana(maana))
				GoldInput.Text = Math.Round(MaanaToEUR(EURToGold(maana)))
				DeviseCAD.Text = Math.Round(MaanaToCAD(maana))
				DeviseEUR.Text = Math.Round(MaanaToEUR(maana))
			Case "MaanasPlusTaxes"
				Dim maana As Double = Minus5Percent(amount)
				MaanasInput.Text = Math.Round(maana)
				MaanasMinusTaxes.Text = Math.Round(Minus5Percent(maana))
				' MaanasPlusTaxes.Text = Math.Round(Plus5Percent(maana))
				SharedMaanas.Text = Math.Round(ShareMaana(maana))
				GoldInput.Text = Math.Round(MaanaToEUR(EURToGold(maana)))
				DeviseCAD.Text = Math.Round(MaanaToCAD(maana))
				DeviseEUR.Text = Math.Round(MaanaToEUR(maana))
			Case "SharedMaanas"
				Dim maana As Double = UnshareMaana(amount)
				MaanasInput.Text = Math.Round(maana)
				MaanasMinusTaxes.Text = Math.Round(Minus5Percent(maana))
				MaanasPlusTaxes.Text = Math.Round(Plus5Percent(maana))
				' SharedMaanas.Text = Math.Round(ShareMaana(maana))
				GoldInput.Text = Math.Round(MaanaToEUR(EURToGold(maana)))
				DeviseCAD.Text = Math.Round(MaanaToCAD(maana))
				DeviseEUR.Text = Math.Round(MaanaToEUR(maana))
			Case "GoldInput"
				Dim maana As Double = EURToMaana(GoldToEUR(amount))
				MaanasInput.Text = Math.Round(maana)
				MaanasMinusTaxes.Text = Math.Round(Minus5Percent(maana))
				MaanasPlusTaxes.Text = Math.Round(Plus5Percent(maana))
				SharedMaanas.Text = Math.Round(ShareMaana(maana))
				' GoldInput.Text = Math.Round(MaanaToEUR(EURToGold(maana)))
				DeviseCAD.Text = Math.Round(GoldToCAD(amount))
				DeviseEUR.Text = Math.Round(GoldToEUR(amount))
			Case "DeviseCAD"
				Dim maana As Double = CADToMaana(amount)
				MaanasInput.Text = Math.Round(maana)
				MaanasMinusTaxes.Text = Math.Round(Minus5Percent(maana))
				MaanasPlusTaxes.Text = Math.Round(Plus5Percent(maana))
				SharedMaanas.Text = Math.Round(ShareMaana(maana))
				GoldInput.Text = Math.Round(CADToGold(amount))
				' DeviseCAD.Text = Math.Round(MaanaToCAD(maana))
				DeviseEUR.Text = Math.Round(GoldToEUR(CADToGold(amount)))
			Case "DeviseEUR"
				Dim maana As Double = EURToMaana(amount)
				MaanasInput.Text = Math.Round(maana)
				MaanasMinusTaxes.Text = Math.Round(Minus5Percent(maana))
				MaanasPlusTaxes.Text = Math.Round(Plus5Percent(maana))
				SharedMaanas.Text = Math.Round(ShareMaana(maana))
				GoldInput.Text = Math.Round(EURToGold(amount))
				DeviseCAD.Text = Math.Round(GoldToCAD(EURToGold(amount)))
				' DeviseEUR.Text = Math.Round(MaanaToEUR(maana))
			Case Else
				Return
		End Select
	End Sub

	' Resets the whole form
	Private Sub ResetButton_Tapped(sender As Object, e As TappedRoutedEventArgs) Handles ResetButton.Tapped
		MaanasInput.Text = 0
		MaanasMinusTaxes.Text = 0
		MaanasPlusTaxes.Text = 0
		SharedMaanas.Text = 0
		GoldInput.Text = 0
		DeviseCAD.Text = 0
		DeviseEUR.Text = 0
	End Sub

	' Activates a cheat code!
	Private Sub Cheat_Code(sender As TextBox, e As TextChangedEventArgs) Handles MaanasInput.TextChanged, GoldInput.TextChanged
		Dim Maana As Double
		Dim Gold As Double
		If Not Double.TryParse(MaanasInput.Text, Maana) Or Not Double.TryParse(GoldInput.Text, Gold) Then Return
		If Not MaanasInput.Text = "1337" Or Not GoldInput.Text = "42" Then Return
		SharedLabel.Visibility = Visibility.Visible
		SharedMaanas.Visibility = Visibility.Visible
		SharedUnits.Visibility = Visibility.Visible
	End Sub

	' Change the color of the control if the input is not a number
	Private Sub ColorControl(sender As TextBox, e As TextChangedEventArgs) Handles MaanasInput.TextChanged, MaanasMinusTaxes.TextChanged, MaanasPlusTaxes.TextChanged, SharedMaanas.TextChanged, GoldInput.TextChanged, DeviseCAD.TextChanged, DeviseEUR.TextChanged
		If Double.TryParse(sender.Text, New Double) Or sender.Text = "" Then
			sender.SelectionHighlightColor.Color = New Color With {
				.R = 0,
				.G = 120,
				.B = 215,
				.A = 255
			}
		Else
			sender.SelectionHighlightColor.Color = Colors.Red
		End If
	End Sub

	Private Sub Navigation_KeyDown(sender As TextBox, e As KeyRoutedEventArgs) Handles MaanasInput.KeyDown, MaanasMinusTaxes.KeyDown, MaanasPlusTaxes.KeyDown, SharedMaanas.KeyDown, GoldInput.KeyDown, DeviseCAD.KeyDown, DeviseEUR.KeyDown
		Dim text As Double
		If Not Double.TryParse(sender.Text, text) Then Return
		e.Handled = True
		Select Case e.Key
			Case VirtualKey.Up, VirtualKey.Add
				sender.Text = text + 1
			Case VirtualKey.Down, VirtualKey.Subtract
				sender.Text = text - 1
			Case VirtualKey.PageUp, VirtualKey.Multiply
				sender.Text = text + 100
			Case VirtualKey.PageDown, VirtualKey.Divide
				sender.Text = text - 100
			Case Else
				e.Handled = False
		End Select
		If sender.Text < 0 Then sender.Text = 0
	End Sub
End Class
