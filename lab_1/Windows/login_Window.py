import sys

from PyQt5 import QtCore, QtWidgets
from PyQt5.QtWidgets import QMainWindow, QApplication
from lab_1.Forms.login_form import Ui_Form_login


class login_Window(QMainWindow):
    def __init__(self, Create_Window, View_Window, parent=None):
        super(login_Window, self).__init__()
        self.ui = Ui_Form_login()
        self.ui.setupUi(self)
        self.Create_Window = Create_Window
        self.View_Window = View_Window
        # Обработчики кнопок
        self.ui.Button_Create.clicked.connect(self.viewCreate)
        self.ui.Button_View.clicked.connect(self.viewView)

    def viewCreate(self):
        self.hide()
        self.Create_Window.Start()

    def viewView(self):
        self.hide()
        # TODO: Сделать проверку правильности файла
        self.View_Window.View_Form(QtWidgets.QFileDialog.getOpenFileName()[0])
