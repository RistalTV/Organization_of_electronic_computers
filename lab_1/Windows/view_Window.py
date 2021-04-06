from PyQt5 import QtCore
from PyQt5.QtWidgets import QMainWindow
from lab_1.Forms.view_form import Ui_Form_view


class view_Window(QMainWindow):
    def __init__(self, parent=None, pathViewFile=""):
        super(view_Window, self).__init__()
        self.ui = Ui_Form_view()
        self.ui.setupUi(self)
        self.pathViewFile = pathViewFile
        # Обработчики кнопок

    def View_Form(self, pathViewFile):
        self.pathViewFile = pathViewFile
        self.show()