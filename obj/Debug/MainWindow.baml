   M S B A M L   `   `   `  ����S  OJob Application Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Job_Application_DatabaseJob_Application_Database  5   	   )    #Job_Application_Database.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   8local&clr-namespace:Job_Application_Database     5   	   -   5          �Name$  
windowMain��5
   	    � Title$ Job Application Database��5   	    � SizeToContent$ WidthAndHeight=�5   	    � UseLayoutRounding .   � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ CanMinimize=�5	   	    � 	Resources 5         ArrowUp �� RelativeSource �� AncestorType	 F�Name
 J� SnapsToDevicePixels  	ArrowDown��%�  &	        &	 H    �� 5   
   .R�5      ]� ��. ��6-   �� *ActualWidth+ �� *FindAncestor+" ��.+�5      F� $	 arrowUp��6   $��1��6(   
�������+����@KL ��� ���� ��� р�� @KL �@KL ��� 	$��Right=�6l   $��20��6�   $��Right=�6�   $��5,0,5,0q�6�   
 . 6�   �� 5      ��6   �� 5      5      �� 5   
   .R�5      ]� ��. ��6-   �� *ActualWidth+ �� *FindAncestor+" ��.+�5      F� $	 	arrowDown��6   $��1��6*   
�������+����@KL @KL р�� ��� ���� @KL �@KL @KL 	$��Right=�6m   $��20��6�   $��Right=�6�   $��5,0,5,0q�6�   
 . 6�   �� 5      ��6   �� 5      5      5      .��5      � -   5         �Name$ mainGrid��5      .+�5!   
   ]� -   5         ]�Name$ dockpanelTop��5!      $	��Top=�6*   $��2��6B   .+�5"      o� $	��Top=�6   $	��Top=�6(   .@�5#      m� $��_File��6   .@�5$      m� -   5         m�Name$ menuitemOpen��5$      $��_Open��65    m� InputGestureText$ Ctrl+O��6D   m� 5%      -   5        $ menuitemSave��5%      $��_Save��65   $ Ctrl+S��6D   �� 5&      m� 5'      -   5        $ menuitemExit��5'      $
��Exit��65   5(      m� 5)      $��_Company��6   .@�5*      m� -   5        $ menuitemNew��5*      $
��_Add��64   $ Ctrl+N��6B   m� 5+      -   5        $ menuitemEdit��5+      $��_Edit��65   $ Ctrl+E��6D   m� 5,      -	   5        $ menuitemDelete��5,      $��Delete��67   $	 Del��6G   5-      m� 5.      $��
Prefrences��6   .@�5/      m� -
   5        $ menuItemAutoload��5/      $��	Auto Load��69    m� IsCheckable .  m� 	IsChecked .   � ToolTip$/ )Auto load last file accessed on start up.��6q   m� 50      -   5        $ menuItemAutoSave��50      $��	Auto Save��69    .  .  $* $Auto save after ever savable action.��6q   51      52      �� 53      -   5         ��Name$ 
labelCount��53      $��Bottom=�6(   $��Count: ��6@   $��10,0,0,0q�6R   � 55       � RowDefinitions 56      �� 57      $
��Auto �6$   �� 58      $
��Auto �6$    � ColumnDefinitions 5:      �� 5;      $
��Auto �6'   �� 5<      $��* �6'   .+�5@      �� -   5         ��Name$ textboxSearch��5@      $��	Search...��61   $��
10,10,10,5q�6B   $��0��6W   �� 5C      -   5         ��Name$ listviewCompanies��5C      $��
10,5,10,10q�66   $	��800��6J   $��Visible=�6V   ��. $��Visible=�5D      $	��390��6S   $��1��6`    5E       �� 
TargetType �� Property �� Value��%T   '��       �� 5F      " ��6    .�5G      ��  � ��$
 Left=�6K   5H      5I       �� View 5J      �� 5K      .P�5L      �� -   5        gridviewcolCompany��$��Company��5L   I    �� Width$	 200��6Z    �� DisplayMemberBinding 6f   �� *Name+�� 5M      -   5        gridviewcolPosition��$��Title��5M   J   $	 180��6Y    6e   �� *
Job.Name+�� 5N      -   5        gridviewcolType��$
��Type��5N   F   $ 80��6T    6_   �� *
Position+�� 5O      -   5        gridviewcolDate��$
��Date��5O   F   $	 100��6T    6`   �� *	AppDate+ �� StringFormat$ 
MM-dd-yyyy���� 5P      -   5        gridviewcolStatus��$��Status��5P   H   $	 200��6X    6d   �� *Status+5Q      5S      � 5V      $��1��6   $��1��6$   $��2��64   $��10q�6E    5W      �� 5X      $
��Auto �6(   �� 5Y      $
��Auto �6(   �� 5Z      $
��Auto �6(   �� 5[      $
��Auto �6(   �� 5\      $
��Auto �6(   �� 5]      $
��Auto �6(   �� 5^      $
��Auto �6(    5`      �� 5a      $
��Auto �6+   .+�5e      �� -   5         ��Name$ buttonNewCompany��5e      $��Add Company��67   $��Center=�6M   $��10q�5f       $	��100��6,   $��Center=�68   $��Center=�6U   $��0��6p   �� 5h      -   5        $ buttonEditCompany��5h      $��Edit Company��68   $��Center=�6O   $��10q�5i   !   $	��100��6-   $��Center=�69   $��Center=�6V   $��1��6q   �� 5k      -   5        $ buttonDeleteCompany��5k      $��Delete Company��6:   $��Center=�6S   $��10q�5l   !   $	��100��6-   $��Center=�69   $��Center=�6V   $��2��6q   �� 5n      -   5        $ buttonEditJobs��5n      $��	Edit Jobs��65   $��Center=�6I   $��10q�5o   !   $	��100��6-   $��Center=�69   $��Center=�6V   $��3��6q   �� 5q      -   5        $ buttonEditReps��5q      $��	Edit Reps��65   $��Center=�6I   $��10q�5r   !   $	��100��6-   $��Center=�69   $��Center=�6V   $��4��6q   �� 5t      -   5        $ buttonEditBoards��5t      $��Edit Job Boards��67   $��Center=�6Q   $��10q�5u   !   $	��100��6-   $��Center=�69   $��Center=�6V   $��5��6q   �� 5w      -   5        $ buttonShowGraph��5w      $��
Show Graph��66   $��Center=�6K   $��10q�5x   !   $	��100��6-   $��Center=�69   $��Center=�6V   $��6��6q   5y      5{      5|      4   .Job_Application_Database.UserControlExitStatus  5}   
   -   5          Name$ 
ExitStatus��5}   &       Exit$  Cancel=�6:   5~      5�      