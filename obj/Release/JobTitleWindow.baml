   M S B A M L   `   `   `  ���� S  OJob Application Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Job_Application_DatabaseJob_Application_Database  -    'Job_Application_Database.JobTitleWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Job_Application_Database     -     � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=� � Title$ 	Edit Jobs�� � SizeToContent$ WidthAndHeight=�.���  � RowDefinitions �� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto �.+��� -    ��Name$ listviewCurrentTitles��$��10q�$	��200��$	��400��$��Visible=���. $��Hidden=�����  �� 
TargetType" ��.�-    �� View �� .P��� $��	Job Title��	 �� Width$		 200��
 �� DisplayMemberBinding
 �� *Title+� $��1��$��Center=�$��Center=� �� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -    ��Name$ buttonAddTitle��$��Add Job��$��10,10,20,10q�$��2��$��0��$	��100��$
��Auto��$��Center=��� -   $ buttonDeleteTitle��$��
Delete Job��$��10,10,20,10q�$��2��$��1��$	��100��$
��Auto��$��Center=��� -   $ buttonEditTitle��$��Edit Job��$��10,10,20,10q�$��2��$��2��$	��100��$
��Auto��$��Center=�