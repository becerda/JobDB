   M S B A M L   `   `   `  ����S  OJob Application Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Job_Application_DatabaseJob_Application_Database  5      1    +Job_Application_Database.BaseCreationWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      8local&clr-namespace:Job_Application_Database     5        � Title$  Base Creation��5       � SizeToContent$ WidthAndHeight=�5       � WindowStartupLocation$ CenterScreen=�5      .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 	labelName��5      $��Name:��6#   $��10q�63   $��0��6?   $��0��6L   �� 5   
   -   5         ��Name$ textboxName��5      $
��Name��6'   $��10,13,10,10q�63   $��0��6H   $��1��6U   $	��190��6e   �� 5   
   -   5        $ 
labelExtra��5      $��Extra:��6$   $��10q�65   $��1��6A   $��0��6N   �� 5   
   -   5        $ textboxExtra��5      $��Extra��6(   $��10,13,10,10q�65   $��1��6J   $��1��6W   $	��190��6g    � ToolTip$ Salary��6s   � 5   
   $��2��6   $��2��6    5      �� 5      $
��Auto �6     5       �� 5!      $��* �6#   �� 5"      $��* �6#   .+�5$      �� -   5         ��Name$ buttonOk��5$      $��Create��6'   $��10q�68   $	��100��6D   $��0��6P   $��0��6]   �� 5%      -   5        $ buttonCancel��5%      $��Cancel��6+   $��10q�6<   $	��100��6H   $��0��6T   $��1��6a   5&      4   .Job_Application_Database.UserControlExitStatus  5(   
   -   5        	  Name$	 
ExitStatus��5(   &   
   Exit$
 Cancel=�6:   5)      5*      