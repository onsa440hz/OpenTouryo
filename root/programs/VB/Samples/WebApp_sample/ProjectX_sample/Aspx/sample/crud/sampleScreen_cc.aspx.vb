﻿'**********************************************************************************
'* フレームワーク・テスト画面（Ｐ層）
'**********************************************************************************

' テスト画面なので、必要に応じて流用 or 削除して下さい。

'**********************************************************************************
'* クラス名        ：sampleScreen_cc
'* クラス日本語名  ：サンプル アプリ画面
'*
'* 作成日時        ：－
'* 作成者          ：生技
'* 更新履歴        ：
'*
'*  日時        更新者            内容
'*  ----------  ----------------  -------------------------------------------------
'*  20xx/xx/xx  ＸＸ ＸＸ         ＸＸＸＸ
'*
'**********************************************************************************

Imports WSIFType_sample

Imports Touryo.Infrastructure.Business.Presentation
Imports Touryo.Infrastructure.Framework.Presentation
Imports Touryo.Infrastructure.Framework.Transmission
Imports Touryo.Infrastructure.Framework.Exceptions

Namespace Aspx.Sample.Crud
    ''' <summary>サンプル アプリ画面</summary>
    Partial Public Class sampleScreen_cc
        Inherits MyBaseController
#Region "Page LoadのUOCメソッド"

        ''' <summary>Page LoadのUOCメソッド（個別：初回Load）</summary>
        ''' <remarks>実装必須</remarks>
        Protected Overrides Sub UOC_FormInit()
            ' Form初期化（初回Load）時に実行する処理を実装する
            ' TODO:
        End Sub

        ''' <summary>Page LoadのUOCメソッド（個別：Post Back）</summary>
        ''' <remarks>実装必須</remarks>
        Protected Overrides Sub UOC_FormInit_PostBack()
            ' Form初期化（Post Back）時に実行する処理を実装する
            ' TODO:
        End Sub

#End Region

#Region "CRUD処理メソッド"

#Region "参照系"

        ''' <summary>
        ''' btnMButton1のClickイベント（件数取得）
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleScreen_btnMButton1_Click(fxEventArgs As FxEventArgs) As String
            ' 引数クラスを生成
            ' 下位（Ｂ・Ｄ層）は、テスト クラスを流用する
            Dim testParameterValue As New TestParameterValue(
                Me.ContentPageFileNoEx, fxEventArgs.ButtonID, "SelectCount",
                Me.ddlDap.SelectedValue & "%" &
                Me.ddlMode1.SelectedValue & "%" &
                Me.ddlMode2.SelectedValue & "%" &
                Me.ddlExRollback.SelectedValue, Me.UserInfo)

            ' 戻り値
            Dim testReturnValue As TestReturnValue

            ' 呼出し制御部品
            Dim cctrl As New CallController(Me.UserInfo)

            ' Invoke
            testReturnValue = cctrl.Invoke(Me.ddlCmctCtrl.SelectedValue, testParameterValue)

            ' 結果表示するMessage エリア
            Dim label As Label = DirectCast(Me.GetMasterWebControl("Label1"), Label)
            label.Text = ""

            If testReturnValue.ErrorFlag = True Then
                ' 結果（業務続行可能なエラー）
                label.Text = "ErrorMessageID:" + testReturnValue.ErrorMessageID & vbCr & vbLf
                label.Text += "ErrorMessage:" + testReturnValue.ErrorMessage & vbCr & vbLf
                label.Text += "ErrorInfo:" + testReturnValue.ErrorInfo & vbCr & vbLf
            Else
                ' 結果（正常系）
                label.Text = testReturnValue.Obj.ToString() & "件のデータがあります"
            End If

            ' 画面遷移しないPost Backの場合は、urlを空文字列に設定する
            Return ""
        End Function

        ''' <summary>
        ''' btnMButton2のClickイベント（一覧取得（dt））
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleScreen_btnMButton2_Click(fxEventArgs As FxEventArgs) As String
            ' 引数クラスを生成
            ' 下位（Ｂ・Ｄ層）は、テスト クラスを流用する
            Dim testParameterValue As New TestParameterValue(
                Me.ContentPageFileNoEx, fxEventArgs.ButtonID, "SelectAll_DT",
                Me.ddlDap.SelectedValue & "%" &
                Me.ddlMode1.SelectedValue & "%" &
                Me.ddlMode2.SelectedValue & "%" &
                Me.ddlExRollback.SelectedValue, Me.UserInfo)

            ' 戻り値
            Dim testReturnValue As TestReturnValue

            ' 呼出し制御部品
            Dim cctrl As New CallController(Me.UserInfo)

            ' Invoke
            testReturnValue = cctrl.Invoke(Me.ddlCmctCtrl.SelectedValue, testParameterValue)

            ' 結果表示するMessage エリア
            Dim label As Label = DirectCast(Me.GetMasterWebControl("Label1"), Label)
            label.Text = ""

            If testReturnValue.ErrorFlag = True Then
                ' 結果（業務続行可能なエラー）
                label.Text = "ErrorMessageID:" + testReturnValue.ErrorMessageID & vbCr & vbLf
                label.Text += "ErrorMessage:" + testReturnValue.ErrorMessage & vbCr & vbLf
                label.Text += "ErrorInfo:" + testReturnValue.ErrorInfo & vbCr & vbLf
            Else
                ' 結果（正常系）
                Me.GridView1.DataSource = testReturnValue.Obj
                Me.GridView1.DataBind()
            End If

            ' 画面遷移しないPost Backの場合は、urlを空文字列に設定する
            Return ""
        End Function

        ''' <summary>
        ''' btnMButton3のClickイベント（一覧取得（ds））
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleScreen_btnMButton3_Click(fxEventArgs As FxEventArgs) As String
            ' 引数クラスを生成
            ' 下位（Ｂ・Ｄ層）は、テスト クラスを流用する
            Dim testParameterValue As New TestParameterValue(
                Me.ContentPageFileNoEx, fxEventArgs.ButtonID, "SelectAll_DS",
                Me.ddlDap.SelectedValue & "%" &
                Me.ddlMode1.SelectedValue & "%" &
                Me.ddlMode2.SelectedValue & "%" &
                Me.ddlExRollback.SelectedValue, Me.UserInfo)

            ' 戻り値
            Dim testReturnValue As TestReturnValue

            ' 呼出し制御部品
            Dim cctrl As New CallController(Me.UserInfo)

            ' Invoke
            testReturnValue = cctrl.Invoke(Me.ddlCmctCtrl.SelectedValue, testParameterValue)

            ' 結果表示するMessage エリア
            Dim label As Label = DirectCast(Me.GetMasterWebControl("Label1"), Label)
            label.Text = ""

            If testReturnValue.ErrorFlag = True Then
                ' 結果（業務続行可能なエラー）
                label.Text = "ErrorMessageID:" + testReturnValue.ErrorMessageID & vbCr & vbLf
                label.Text += "ErrorMessage:" + testReturnValue.ErrorMessage & vbCr & vbLf
                label.Text += "ErrorInfo:" + testReturnValue.ErrorInfo & vbCr & vbLf
            Else
                ' 結果（正常系）
                Dim ds As DataSet = DirectCast(testReturnValue.Obj, DataSet)
                Me.GridView1.DataSource = ds.Tables(0)
                Me.GridView1.DataBind()
            End If

            ' 画面遷移しないPost Backの場合は、urlを空文字列に設定する
            Return ""
        End Function

        ''' <summary>
        ''' btnMButton4のClickイベント（一覧取得（dr））
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleScreen_btnMButton4_Click(fxEventArgs As FxEventArgs) As String
            ' 引数クラスを生成
            ' 下位（Ｂ・Ｄ層）は、テスト クラスを流用する
            Dim testParameterValue As New TestParameterValue(
                Me.ContentPageFileNoEx, fxEventArgs.ButtonID, "SelectAll_DR",
                Me.ddlDap.SelectedValue & "%" &
                Me.ddlMode1.SelectedValue & "%" &
                Me.ddlMode2.SelectedValue & "%" &
                Me.ddlExRollback.SelectedValue, Me.UserInfo)

            ' 戻り値
            Dim testReturnValue As TestReturnValue

            ' 呼出し制御部品
            Dim cctrl As New CallController(Me.UserInfo)

            ' Invoke
            testReturnValue = cctrl.Invoke(Me.ddlCmctCtrl.SelectedValue, testParameterValue)

            ' 結果表示するMessage エリア
            Dim label As Label = DirectCast(Me.GetMasterWebControl("Label1"), Label)
            label.Text = ""

            If testReturnValue.ErrorFlag = True Then
                ' 結果（業務続行可能なエラー）
                label.Text = "ErrorMessageID:" + testReturnValue.ErrorMessageID & vbCr & vbLf
                label.Text += "ErrorMessage:" + testReturnValue.ErrorMessage & vbCr & vbLf
                label.Text += "ErrorInfo:" + testReturnValue.ErrorInfo & vbCr & vbLf
            Else
                ' 結果（正常系）
                Me.GridView1.DataSource = testReturnValue.Obj
                Me.GridView1.DataBind()
            End If

            ' 画面遷移しないPost Backの場合は、urlを空文字列に設定する
            Return ""
        End Function

        ''' <summary>
        ''' btnMButton5のClickイベント（一覧取得（動的sql））
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleScreen_btnMButton5_Click(fxEventArgs As FxEventArgs) As String
            ' 引数クラスを生成
            ' 下位（Ｂ・Ｄ層）は、テスト クラスを流用する
            Dim testParameterValue As New TestParameterValue(
                Me.ContentPageFileNoEx, fxEventArgs.ButtonID, "SelectAll_DSQL",
                Me.ddlDap.SelectedValue & "%" &
                Me.ddlMode1.SelectedValue & "%" &
                Me.ddlMode2.SelectedValue & "%" &
                Me.ddlExRollback.SelectedValue, Me.UserInfo)

            ' 動的SQLの要素を設定
            testParameterValue.OrderColumn = Me.ddlOrderColumn.SelectedValue
            testParameterValue.OrderSequence = Me.ddlOrderSequence.SelectedValue

            ' 戻り値
            Dim testReturnValue As TestReturnValue

            ' 呼出し制御部品
            Dim cctrl As New CallController(Me.UserInfo)

            ' Invoke
            testReturnValue = cctrl.Invoke(Me.ddlCmctCtrl.SelectedValue, testParameterValue)

            ' 結果表示するMessage エリア
            Dim label As Label = DirectCast(Me.GetMasterWebControl("Label1"), Label)
            label.Text = ""

            If testReturnValue.ErrorFlag = True Then
                ' 結果（業務続行可能なエラー）
                label.Text = "ErrorMessageID:" + testReturnValue.ErrorMessageID & vbCr & vbLf
                label.Text += "ErrorMessage:" + testReturnValue.ErrorMessage & vbCr & vbLf
                label.Text += "ErrorInfo:" + testReturnValue.ErrorInfo & vbCr & vbLf
            Else
                ' 結果（正常系）
                Me.GridView1.DataSource = testReturnValue.Obj
                Me.GridView1.DataBind()
            End If

            ' 画面遷移しないPost Backの場合は、urlを空文字列に設定する
            Return ""
        End Function

        ''' <summary>
        ''' btnMButton6のClickイベント（参照処理）
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleScreen_btnMButton6_Click(fxEventArgs As FxEventArgs) As String
            ' 引数クラスを生成
            ' 下位（Ｂ・Ｄ層）は、テスト クラスを流用する
            Dim testParameterValue As New TestParameterValue(
                Me.ContentPageFileNoEx, fxEventArgs.ButtonID, "Select",
                Me.ddlDap.SelectedValue & "%" &
                Me.ddlMode1.SelectedValue & "%" &
                Me.ddlMode2.SelectedValue & "%" &
                Me.ddlExRollback.SelectedValue, Me.UserInfo)

            ' 情報の設定
            testParameterValue.ShipperID = Integer.Parse(Me.TextBox1.Text)

            ' 戻り値
            Dim testReturnValue As TestReturnValue

            ' 呼出し制御部品
            Dim cctrl As New CallController(Me.UserInfo)

            ' Invoke
            testReturnValue = cctrl.Invoke(Me.ddlCmctCtrl.SelectedValue, testParameterValue)

            ' 結果表示するMessage エリア
            Dim label As Label = DirectCast(Me.GetMasterWebControl("Label1"), Label)
            label.Text = ""

            If testReturnValue.ErrorFlag = True Then
                ' 結果（業務続行可能なエラー）
                label.Text = "ErrorMessageID:" + testReturnValue.ErrorMessageID & vbCr & vbLf
                label.Text += "ErrorMessage:" + testReturnValue.ErrorMessage & vbCr & vbLf
                label.Text += "ErrorInfo:" + testReturnValue.ErrorInfo & vbCr & vbLf
            Else
                ' 結果（正常系）
                Me.TextBox1.Text = testReturnValue.ShipperID.ToString()
                Me.TextBox2.Text = testReturnValue.CompanyName
                Me.TextBox3.Text = testReturnValue.Phone
            End If

            ' 画面遷移しないPost Backの場合は、urlを空文字列に設定する
            Return ""
        End Function

#End Region

#Region "更新系"

        ''' <summary>
        ''' btnMButton7のClickイベント（追加処理）
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleScreen_btnMButton7_Click(fxEventArgs As FxEventArgs) As String
            ' 引数クラスを生成
            ' 下位（Ｂ・Ｄ層）は、テスト クラスを流用する
            Dim testParameterValue As New TestParameterValue(
                Me.ContentPageFileNoEx, fxEventArgs.ButtonID, "Insert",
                Me.ddlDap.SelectedValue & "%" &
                Me.ddlMode1.SelectedValue & "%" &
                Me.ddlMode2.SelectedValue & "%" &
                Me.ddlExRollback.SelectedValue, Me.UserInfo)

            ' 情報の設定
            testParameterValue.CompanyName = Me.TextBox2.Text
            testParameterValue.Phone = Me.TextBox3.Text

            ' 戻り値
            Dim testReturnValue As TestReturnValue

            ' 呼出し制御部品
            Dim cctrl As New CallController(Me.UserInfo)

            ' Invoke
            testReturnValue = cctrl.Invoke(Me.ddlCmctCtrl.SelectedValue, testParameterValue)

            ' 結果表示するMessage エリア
            Dim label As Label = DirectCast(Me.GetMasterWebControl("Label1"), Label)
            label.Text = ""

            If testReturnValue.ErrorFlag = True Then
                ' 結果（業務続行可能なエラー）
                label.Text = "ErrorMessageID:" + testReturnValue.ErrorMessageID & vbCr & vbLf
                label.Text += "ErrorMessage:" + testReturnValue.ErrorMessage & vbCr & vbLf
                label.Text += "ErrorInfo:" + testReturnValue.ErrorInfo & vbCr & vbLf
            Else
                ' 結果（正常系）
                label.Text = testReturnValue.Obj.ToString() & "件追加"
            End If

            ' 画面遷移しないPost Backの場合は、urlを空文字列に設定する
            Return ""
        End Function

        ''' <summary>
        ''' btnMButton8のClickイベント（更新処理）
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleScreen_btnMButton8_Click(fxEventArgs As FxEventArgs) As String
            ' 引数クラスを生成
            ' 下位（Ｂ・Ｄ層）は、テスト クラスを流用する
            Dim testParameterValue As New TestParameterValue(
                Me.ContentPageFileNoEx, fxEventArgs.ButtonID, "Update",
                Me.ddlDap.SelectedValue & "%" &
                Me.ddlMode1.SelectedValue & "%" &
                Me.ddlMode2.SelectedValue & "%" &
                Me.ddlExRollback.SelectedValue, Me.UserInfo)

            ' 情報の設定
            testParameterValue.ShipperID = Integer.Parse(Me.TextBox1.Text)
            testParameterValue.CompanyName = Me.TextBox2.Text
            testParameterValue.Phone = Me.TextBox3.Text

            ' 戻り値
            Dim testReturnValue As TestReturnValue

            ' 呼出し制御部品
            Dim cctrl As New CallController(Me.UserInfo)

            ' Invoke
            testReturnValue = cctrl.Invoke(Me.ddlCmctCtrl.SelectedValue, testParameterValue)

            ' 結果表示するMessage エリア
            Dim label As Label = DirectCast(Me.GetMasterWebControl("Label1"), Label)
            label.Text = ""

            If testReturnValue.ErrorFlag = True Then
                ' 結果（業務続行可能なエラー）
                label.Text = "ErrorMessageID:" + testReturnValue.ErrorMessageID & vbCr & vbLf
                label.Text += "ErrorMessage:" + testReturnValue.ErrorMessage & vbCr & vbLf
                label.Text += "ErrorInfo:" + testReturnValue.ErrorInfo & vbCr & vbLf
            Else
                ' 結果（正常系）
                label.Text = testReturnValue.Obj.ToString() & "件更新"
            End If

            ' 画面遷移しないPost Backの場合は、urlを空文字列に設定する
            Return ""
        End Function

        ''' <summary>
        ''' btnMButton9のClickイベント（削除処理）
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleScreen_btnMButton9_Click(fxEventArgs As FxEventArgs) As String
            ' 引数クラスを生成
            ' 下位（Ｂ・Ｄ層）は、テスト クラスを流用する
            Dim testParameterValue As New TestParameterValue(
                Me.ContentPageFileNoEx, fxEventArgs.ButtonID, "Delete",
                Me.ddlDap.SelectedValue & "%" &
                Me.ddlMode1.SelectedValue & "%" &
                Me.ddlMode2.SelectedValue & "%" &
                Me.ddlExRollback.SelectedValue, Me.UserInfo)

            ' 情報の設定
            testParameterValue.ShipperID = Integer.Parse(TextBox1.Text)

            ' 戻り値
            Dim testReturnValue As TestReturnValue

            ' 呼出し制御部品
            Dim cctrl As New CallController(Me.UserInfo)

            ' Invoke
            testReturnValue = cctrl.Invoke(Me.ddlCmctCtrl.SelectedValue, testParameterValue)

            ' 結果表示するMessage エリア
            Dim label As Label = DirectCast(Me.GetMasterWebControl("Label1"), Label)
            label.Text = ""

            If testReturnValue.ErrorFlag = True Then
                ' 結果（業務続行可能なエラー）
                label.Text = "ErrorMessageID:" + testReturnValue.ErrorMessageID & vbCr & vbLf
                label.Text += "ErrorMessage:" + testReturnValue.ErrorMessage & vbCr & vbLf
                label.Text += "ErrorInfo:" + testReturnValue.ErrorInfo & vbCr & vbLf
            Else
                ' 結果（正常系）
                label.Text = testReturnValue.Obj.ToString() & "件削除"
            End If

            ' 画面遷移しないPost Backの場合は、urlを空文字列に設定する
            Return ""
        End Function

#End Region

#End Region

#Region "Ｐ層で例外をスロー"

        ''' <summary>
        ''' btnButton1のClickイベント（業務例外）
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_btnButton1_Click(fxEventArgs As FxEventArgs) As String
            Throw New BusinessApplicationException("Ｐ層で「業務例外」をスロー", "Ｐ層で「業務例外」をスロー", "Ｐ層で「業務例外」をスロー")
        End Function

        ''' <summary>
        ''' btnButton2のClickイベント（システム例外）
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_btnButton2_Click(fxEventArgs As FxEventArgs) As String
            Throw New BusinessSystemException("Ｐ層で「システム例外」をスロー", "Ｐ層で「システム例外」をスロー")
        End Function

        ''' <summary>
        ''' btnButton3のClickイベント（その他、一般的な例外）
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_btnButton3_Click(fxEventArgs As FxEventArgs) As String
            Throw New Exception("Ｐ層で「その他、一般的な例外」をスロー")
        End Function

        ''' <summary>
        ''' btnButton4のClickイベント（その他、一般的な例外）
        ''' </summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_btnButton4_Click(fxEventArgs As FxEventArgs) As String
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()

            Return ""
        End Function

#End Region

#Region "Master Page、User Controlのイベント"

        ''' <summary>Master PageにEvent Handlerを実装可能にしたのでそのテスト。</summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleScreen_btnMPButton_Click(fxEventArgs As FxEventArgs) As String
            Me.lblResult.Text = "sampleScreen.masterのbtnMPButtonのClickイベントを、UOC_sampleScreen_btnMPButton_Clickで実行"

            Return ""
        End Function

        ''' <summary>User ControlにEvent Handlerを実装可能にしたのでそのテスト。</summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleControl1_btnUCButton_Click(fxEventArgs As FxEventArgs) As String
            Me.lblResult.Text = "sampleControl.ascxのbtnUCButtonのClickイベントを、UOC_sampleControl1_btnUCButton_Clickで実行"

            Return ""
        End Function

        ''' <summary>User ControlにEvent Handlerを実装可能にしたのでそのテスト。</summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_sampleControl2_btnUCButton_Click(fxEventArgs As FxEventArgs) As String
            Me.lblResult.Text = "sampleControl.ascxのbtnUCButtonのClickイベントを、UOC_sampleControl2_btnUCButton_Clickで実行"

            Return ""
        End Function

#End Region

    End Class
End Namespace
