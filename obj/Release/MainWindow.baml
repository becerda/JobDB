   M S B A M L   `   `   `  ���� S  OJob Application Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Job_Application_Database.Commands!Job_Application_Database.Commands  )    #Job_Application_Database.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @self/clr-namespace:Job_Application_Database.Commands     -     �Name$  
windowMain�� � Title$ Job Application Database�� � SizeToContent$ WidthAndHeight=� � UseLayoutRounding .   � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� � 	Resources    ArrowUp �� RelativeSource �� AncestorType	 F�Name
 J� SnapsToDevicePixels  	ArrowDown��%�  &	        &	 �     �� .R�]� ��. ���� *ActualWidth+ �� *FindAncestor+" ��.+�F� $	 arrowUp��$��1��
�������+����@KL ��� ���� ��� р�� @KL �@KL ��� 	$��Right=�$��20��$��Right=�$��5,0,5,0q�
 . �� ���� �� .R�]� ��. ���� *ActualWidth+ �� *FindAncestor+" ��.+�F� $	 	arrowDown��$��1��
�������+����@KL @KL р�� ��� ���� @KL �@KL @KL 	$��Right=�$��20��$��Right=�$��5,0,5,0q�
 . �� ���� .��� -    �Name$ mainGrid��.+�]� -    ]�Name$ dockpanelTop��$	��Top=�$��2��.+�o� $	��Top=�$	��Top=�.@�m� $��_File��.@�m� -    m�Name$ menuitemNew��$
��_New�� m� InputGestureText$ Ctrl+N��m� -   $ menuitemOpen��$��_Open��$ Ctrl+O��m� -   $ menuitemSave��$��_Save��$ Ctrl+S���� m� -   $ menuitemExit��$
��Exit��m� $��_Company��.@�m� -   $ menuitemAdd��$
��_Add��$ Ctrl+Shift+A��m� -	   $ menuitemEdit��$��_Edit��$ Ctrl+E��m� -
   $ menuitemDelete��$��Delete��$	 Del��m� $��
Prefrences��.@�m� -   $ menuItemAutoload��$��	Auto Load�� m� IsCheckable .  m� 	IsChecked .   � ToolTip$/ )Auto load last file accessed on start up.��m� -   $ menuItemAutoSave��$��	Auto Save�� .  .  $* $Auto save after ever savable action.���� -    ��Name$ 
labelCount��$��Bottom=�$��Count: ��$��10,0,0,0q��  � RowDefinitions �� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� -    ��Name$ textboxSearch��$��	Search...��$��
10,10,10,5q�$��0���� -    ��Name$ listviewCompanies��$��
10,5,10,10q�$	��800��$��Visible=���. $��Visible=�$	��390��$��1������  �� 
TargetType" ��.�-    �� View �� .P��� -   gridviewcolCompany��$��Company�� �� Width$	 200�� �� DisplayMemberBinding �� *Name+�� -   gridviewcolPosition��$��Title��$	 180�� �� *	Job.Title+�� -   gridviewcolType��$
��Type��$ 80�� �� *
Position+�� -   gridviewcolStatus��$��Status��$	 220�� �� *Status+� $��0��$��1��$��2��$��10q� �� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto �.+��� -    ��Name$ buttonNewCompany��$��Add Company��$��Center=�$��10q�$	��100��$��Center=�$��Center=�$��0���� -   $ buttonDeleteCompany��$��Delete Company��$��Center=�$��10q�$	��100��$��Center=�$��Center=�$��1���� -   $ buttonEditTitles��$��	Edit Jobs��$��Center=�$��10q�$	��100��$��Center=�$��Center=�$��2��