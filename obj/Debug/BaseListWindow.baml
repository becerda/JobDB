   M S B A M L   `   `   `  ����S  OJob Application Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Job_Application_DatabaseJob_Application_Database  5   	   -    'Job_Application_Database.BaseListWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Job_Application_Database     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ 	Edit Jobs��5
   	    � SizeToContent$ WidthAndHeight=�6   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ listviewCurrent��5      $��10q�6,   $	��200��68   $	��400��6D   $��Visible=�6Q   ��. $��Hidden=�6�    �� View 5      �� 5      .P�5      �� $��	Job Title��6%    �� Width$	 200��68   	 �� DisplayMemberBinding	 6D   �� *Name+5      5      � 5   
   $��1��6   $��Center=�6   $��Center=�6<    5      �� 5      $��* �6#    5       �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    .+�5%      �� -   5        
 ��Name$
 	buttonAdd��5%      $��Add Job��6(   $��10,10,20,10q�6:   $��2��6O   $��0��6_   $	��100��6l   $
��Auto��6x   $��Center=�6�   �� 5&      -   5        $
 buttonDelete��5&      $��
Delete Job��6+   $��10,10,20,10q�6@   $��2��6U   $��1��6e   $	��100��6r   $
��Auto��6~   $��Center=�6�   �� 5'      -   5        $
 
buttonEdit��5'      $��Edit Job��6)   $��10,10,20,10q�6<   $��2��6Q   $��2��6a   $	��100��6n   $
��Auto��6z   $��Center=�6�   5(      4   .Job_Application_Database.UserControlExitStatus  5*   
   -   5          Name$ 
ExitStatus��5*   &      Exit$ Cancel=�6:   5+      5,      