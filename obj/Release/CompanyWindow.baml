   M S B A M L   `   `   `  ���� S  OJob Application Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Job_Application_DatabaseJob_Application_Database  4    .Job_Application_Database.CompanyCreationWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Job_Application_Database       � Title$  Add New Company�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.��� -    �Name$ gridMain�� � RowDefinitions �� $
��Auto ��� $
��Auto �.+��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto �.+��� -    ��Name$ 
labelCName��$��Company Name:��$��10q��� -    ��Name$ textBoxCName��$��23��$
��Name��$��Center=�$��10,13,10,10q�$��1��$	��190���� -   $ 
labelTitle��$��Title:��$��10q�$��1���� -   	 ��Name$	 comboBoxTitle��$��1��$��10,13,10,10q�$��1��$��Center=�$	��190��
 �� SelectedIndex$
 0���� -   $ labelLocation��$��	Location:��$��10q�$��2���� -   $ textBoxLocation��$��23�� �� TextWrapping$
 Wrap=�$��Location��$��Center=�$��10,13,10,10q�$��1��$��2��$	��190���� -   $ 	labelDate��$��Date Applied:��$��10q�$��3��(  "System.Windows.Controls.DatePicker  -	     Name$ datepickerAppDate��$��3��$��1��$��Center=�$��10,13,10,10q�$	��190���� -
   $ labelStatus��$��Status:��$��10q�$��4��$
��Left=�$	��Top=�� $��4��$��1��$��0q�$��2�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto �.+��� -    ��Name$ checkboxApplied��$
��Left=�$��Center=�$��Applied��$��10,5,5,5q��� -   $ checkboxHunted��$
��Left=�$��Center=�$��Hunted��$��10,5,5,5q�$��1���� -   $ checkboxAssign��$
��Left=�$��Center=�$��
Assignment��$��10,5,5,5q�$��1���� -   $ checkboxInterview��$
��Left=�$��Center=�$��	Interview��$��10,5,5,5q�$��1��$��1���� -   $ checkboxOffered��$
��Left=�$��Center=�$��Offered��$��10,5,5,5q�$��2���� -   $ checkboxAccepted��$
��Left=�$��Center=�$��Accepted��$��10,5,5,5q�$��2��$��1���� -   $ checkboxDenied��$
��Left=�$��Center=�$��Denied��$��10,5,5,5q�$��3���� -   $ checkboxRejected��$
��Left=�$��Center=�$��Rejected��$��10,5,5,5q�$��3��$��1��	� -    	�Name$ 
checkboxNA�� 	� 	GroupName$ JobType��$
��Left=�$��Center=�$	��N/A��$��10,5,5,5q�$��4��$��0��	� -   $ checkboxPartTime��$ JobType��$
��Left=�$��Center=�$��	Part-Time��$��10,5,5,5q�$��4��$��1��	� -   $ checkboxFullTime��$ JobType��$
��Left=�$��Center=�$��	Full-Time��$��10,5,5,5q�$��5��	� -   $ checkboxContract��$ JobType��$
��Left=�$��Center=�$��Contract��$��10,5,5,5q�$��5��$��1���� -   $ 	labelType��$��	Job Type:��$��10q�$��5��$
��Left=�$��Center=�� $��5��$��1�� �� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� -   $ 
labelNotes��$��Notes:��$��10q�$��6��$
��Left=�$	��Top=��� -   $ textboxNotes��$��Notes��$��6��$��1��$��	0,10,5,10q�$	��100��$	��190��� $��1�� �� $��* ��� $��* �.+��� -    ��Name$ buttonCreate��$��Create��$	��100��$��10q�$��0��$��0���� -   $ buttonCancel��$��Cancel��$	��100��$��10q�$��0��$��1��