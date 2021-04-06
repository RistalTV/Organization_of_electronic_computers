# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'view_form.ui'
#
# Created by: PyQt5 UI code generator 5.15.4
#
# WARNING: Any manual changes made to this file will be lost when pyuic5 is
# run again.  Do not edit this file unless you know what you are doing.


from PyQt5 import QtCore, QtGui, QtWidgets


class Ui_Form_view(object):
    def setupUi(self, Form_view):
        Form_view.setObjectName("Form_view")
        Form_view.resize(800, 525)
        Form_view.setMinimumSize(QtCore.QSize(800, 525))
        Form_view.setMaximumSize(QtCore.QSize(16777215, 525))
        Form_view.setStyleSheet("display: block;\n"
"    color: rgb(197, 197, 197);\n"
"    text-align: center;\n"
"    padding: 14px 16px;\n"
"    text-decoration: none;\n"
"background: #454545;")
        self.gridLayoutWidget = QtWidgets.QWidget(Form_view)
        self.gridLayoutWidget.setGeometry(QtCore.QRect(-1, -1, 802, 531))
        self.gridLayoutWidget.setObjectName("gridLayoutWidget")
        self.gridLayout = QtWidgets.QGridLayout(self.gridLayoutWidget)
        self.gridLayout.setContentsMargins(0, 0, 0, 0)
        self.gridLayout.setObjectName("gridLayout")
        self.Output = QtWidgets.QGraphicsView(self.gridLayoutWidget)
        self.Output.setMinimumSize(QtCore.QSize(800, 390))
        self.Output.setMaximumSize(QtCore.QSize(16777215, 373))
        self.Output.setHorizontalScrollBarPolicy(QtCore.Qt.ScrollBarAlwaysOn)
        self.Output.setDragMode(QtWidgets.QGraphicsView.ScrollHandDrag)
        self.Output.setCacheMode(QtWidgets.QGraphicsView.CacheBackground)
        self.Output.setObjectName("Output")
        self.gridLayout.addWidget(self.Output, 0, 0, 1, 1)
        self.gridLayout_4 = QtWidgets.QGridLayout()
        self.gridLayout_4.setContentsMargins(10, 5, 10, 5)
        self.gridLayout_4.setHorizontalSpacing(0)
        self.gridLayout_4.setObjectName("gridLayout_4")
        self.gridLayout_2 = QtWidgets.QGridLayout()
        self.gridLayout_2.setContentsMargins(5, 5, 5, 5)
        self.gridLayout_2.setHorizontalSpacing(0)
        self.gridLayout_2.setObjectName("gridLayout_2")
        self.Btn_random = QtWidgets.QPushButton(self.gridLayoutWidget)
        self.Btn_random.setMaximumSize(QtCore.QSize(16777215, 50))
        font = QtGui.QFont()
        font.setPointSize(6)
        font.setBold(True)
        font.setUnderline(False)
        font.setWeight(87)
        font.setStrikeOut(False)
        self.Btn_random.setFont(font)
        self.Btn_random.setStyleSheet("QPushButton#Btn_random {\n"
"  display: inline-block;\n"
"  color: white;\n"
"  font-weight: 700;\n"
"  text-decoration: none;\n"
"  user-select: none;\n"
"  outline: none;\n"
"  border: 2px solid;\n"
"  border-radius: 1px;\n"
"  transition: 0.2s;\n"
"} \n"
"QPushButton#Btn_random:hover { background: rgba(255,255,255,.2); }\n"
"QPushButton#Btn_random:pressed { background: rgb(170, 255, 255); }")
        self.Btn_random.setObjectName("Btn_random")
        self.gridLayout_2.addWidget(self.Btn_random, 1, 0, 1, 1)
        self.Btn_update = QtWidgets.QPushButton(self.gridLayoutWidget)
        self.Btn_update.setMaximumSize(QtCore.QSize(16777215, 50))
        font = QtGui.QFont()
        font.setPointSize(6)
        font.setBold(True)
        font.setUnderline(False)
        font.setWeight(87)
        font.setStrikeOut(False)
        self.Btn_update.setFont(font)
        self.Btn_update.setTabletTracking(True)
        self.Btn_update.setStyleSheet("QPushButton#Btn_update {\n"
"  display: inline-block;\n"
"  color: white;\n"
"  font-weight: 700;\n"
"  text-decoration: none;\n"
"  user-select: none;\n"
"  outline: none;\n"
"  border: 2px solid;\n"
"  border-radius: 1px;\n"
"  transition: 0.2s;\n"
"} \n"
"\n"
"QPushButton#Btn_update:hover { background: rgba(255,255,255,.2); }\n"
"QPushButton#Btn_update:pressed { background: white; }")
        self.Btn_update.setObjectName("Btn_update")
        self.gridLayout_2.addWidget(self.Btn_update, 0, 0, 1, 1)
        self.Btn_reset = QtWidgets.QPushButton(self.gridLayoutWidget)
        self.Btn_reset.setMaximumSize(QtCore.QSize(16777215, 50))
        font = QtGui.QFont()
        font.setPointSize(6)
        font.setBold(True)
        font.setUnderline(False)
        font.setWeight(87)
        font.setStrikeOut(False)
        self.Btn_reset.setFont(font)
        self.Btn_reset.setMouseTracking(False)
        self.Btn_reset.setStyleSheet("QPushButton#Btn_reset {\n"
"  display: inline-block;\n"
"  color: white;\n"
"  font-weight: 700;\n"
"  text-decoration: none;\n"
"  user-select: none;\n"
"  outline: none;\n"
"  border: 2px solid;\n"
"  border-radius: 1px;\n"
"  transition: 0.2s;\n"
"} \n"
"QPushButton#Btn_reset:hover { background: rgba(255,255,255,.2); }\n"
"QPushButton#Btn_reset:pressed { background: rgb(194, 0, 0); }")
        self.Btn_reset.setObjectName("Btn_reset")
        self.gridLayout_2.addWidget(self.Btn_reset, 0, 1, 1, 1)
        self.gridLayout_4.addLayout(self.gridLayout_2, 0, 0, 1, 1)
        self.verticalLayout = QtWidgets.QVBoxLayout()
        self.verticalLayout.setContentsMargins(5, 2, 5, 10)
        self.verticalLayout.setSpacing(0)
        self.verticalLayout.setObjectName("verticalLayout")
        self.gridLayout_3 = QtWidgets.QGridLayout()
        self.gridLayout_3.setSizeConstraint(QtWidgets.QLayout.SetMinimumSize)
        self.gridLayout_3.setContentsMargins(5, 0, 5, 10)
        self.gridLayout_3.setSpacing(0)
        self.gridLayout_3.setObjectName("gridLayout_3")
        self.label = QtWidgets.QLabel(self.gridLayoutWidget)
        self.label.setMinimumSize(QtCore.QSize(80, 50))
        self.label.setMaximumSize(QtCore.QSize(80, 50))
        font = QtGui.QFont()
        font.setPointSize(6)
        font.setBold(True)
        font.setUnderline(False)
        font.setWeight(87)
        font.setStrikeOut(False)
        self.label.setFont(font)
        self.label.setStyleSheet("  display: inline-block;\n"
"  color: white;\n"
"  font-weight: 700;\n"
"  text-decoration: none;\n"
"  user-select: none;\n"
"  transition: 0.2s;\n"
"")
        self.label.setTextFormat(QtCore.Qt.RichText)
        self.label.setObjectName("label")
        self.gridLayout_3.addWidget(self.label, 0, 0, 1, 1)
        self.Input_frequenceMK = QtWidgets.QSpinBox(self.gridLayoutWidget)
        self.Input_frequenceMK.setMinimumSize(QtCore.QSize(80, 0))
        self.Input_frequenceMK.setMaximumSize(QtCore.QSize(120, 50))
        font = QtGui.QFont()
        font.setPointSize(6)
        font.setBold(True)
        font.setUnderline(False)
        font.setWeight(87)
        font.setStrikeOut(False)
        self.Input_frequenceMK.setFont(font)
        self.Input_frequenceMK.setStyleSheet("QSpinBox#Input_frequenceMK {\n"
"  display: inline-block;\n"
"  color: white;\n"
"  font-weight: 700;\n"
"  text-decoration: none;\n"
"  user-select: none;\n"
"  padding: .5em 2em;\n"
"  outline: none;\n"
"  border: 2px solid;\n"
"  border-radius: 1px;\n"
"  transition: 0.2s;\n"
"} \n"
"\n"
"QSpinBox#Input_frequenceMK:hover { background: rgba(255,255,255,.2); }\n"
"QSpinBox#Input_frequenceMK:pressed { background: white; }")
        self.Input_frequenceMK.setObjectName("Input_frequenceMK")
        self.gridLayout_3.addWidget(self.Input_frequenceMK, 0, 1, 1, 1)
        self.label_2 = QtWidgets.QLabel(self.gridLayoutWidget)
        self.label_2.setMinimumSize(QtCore.QSize(85, 50))
        self.label_2.setMaximumSize(QtCore.QSize(80, 50))
        font = QtGui.QFont()
        font.setPointSize(6)
        font.setBold(True)
        font.setUnderline(False)
        font.setWeight(87)
        font.setStrikeOut(False)
        self.label_2.setFont(font)
        self.label_2.setStyleSheet("  display: inline-block;\n"
"  color: white;\n"
"  font-weight: 700;\n"
"  text-decoration: none;\n"
"  user-select: none;\n"
"  transition: 0.2s;\n"
"")
        self.label_2.setTextFormat(QtCore.Qt.RichText)
        self.label_2.setObjectName("label_2")
        self.gridLayout_3.addWidget(self.label_2, 0, 2, 1, 1)
        self.label_3 = QtWidgets.QLabel(self.gridLayoutWidget)
        self.label_3.setMinimumSize(QtCore.QSize(84, 50))
        self.label_3.setMaximumSize(QtCore.QSize(80, 50))
        font = QtGui.QFont()
        font.setPointSize(6)
        font.setBold(True)
        font.setUnderline(False)
        font.setWeight(87)
        font.setStrikeOut(False)
        self.label_3.setFont(font)
        self.label_3.setStyleSheet("  display: inline-block;\n"
"  color: white;\n"
"  font-weight: 700;\n"
"  text-decoration: none;\n"
"  user-select: none;\n"
"  transition: 0.2s;\n"
"")
        self.label_3.setTextFormat(QtCore.Qt.RichText)
        self.label_3.setObjectName("label_3")
        self.gridLayout_3.addWidget(self.label_3, 0, 4, 1, 1)
        self.Input_frequenceSB = QtWidgets.QSpinBox(self.gridLayoutWidget)
        self.Input_frequenceSB.setMinimumSize(QtCore.QSize(80, 0))
        self.Input_frequenceSB.setMaximumSize(QtCore.QSize(120, 50))
        font = QtGui.QFont()
        font.setPointSize(6)
        font.setBold(True)
        font.setUnderline(False)
        font.setWeight(87)
        font.setStrikeOut(False)
        self.Input_frequenceSB.setFont(font)
        self.Input_frequenceSB.setStyleSheet("QSpinBox#Input_frequenceSB {\n"
"  display: inline-block;\n"
"  color: white;\n"
"  font-weight: 700;\n"
"  text-decoration: none;\n"
"  user-select: none;\n"
"  padding: .5em 2em;\n"
"  outline: none;\n"
"  border: 2px solid;\n"
"  border-radius: 1px;\n"
"  transition: 0.2s;\n"
"} \n"
"\n"
"QSpinBox#Input_frequenceSB:hover { background: rgba(255,255,255,.2); }\n"
"QSpinBox#Input_frequenceSB:pressed { background: white; }")
        self.Input_frequenceSB.setObjectName("Input_frequenceSB")
        self.gridLayout_3.addWidget(self.Input_frequenceSB, 0, 3, 1, 1)
        self.Input_formRAM = QtWidgets.QSpinBox(self.gridLayoutWidget)
        self.Input_formRAM.setMinimumSize(QtCore.QSize(80, 0))
        self.Input_formRAM.setMaximumSize(QtCore.QSize(120, 50))
        font = QtGui.QFont()
        font.setPointSize(6)
        font.setBold(True)
        font.setUnderline(False)
        font.setWeight(87)
        font.setStrikeOut(False)
        self.Input_formRAM.setFont(font)
        self.Input_formRAM.setStyleSheet("QSpinBox#Input_formRAM {\n"
"  display: inline-block;\n"
"  color: white;\n"
"  font-weight: 700;\n"
"  text-decoration: none;\n"
"  user-select: none;\n"
"  padding: .5em 2em;\n"
"  outline: none;\n"
"  border: 2px solid;\n"
"  border-radius: 1px;\n"
"  transition: 0.2s;\n"
"} \n"
"QSpinBox#Input_formRAM:hover { background: rgba(255,255,255,.2); }\n"
"QSpinBox#Input_formRAM:pressed { background: white; }")
        self.Input_formRAM.setObjectName("Input_formRAM")
        self.gridLayout_3.addWidget(self.Input_formRAM, 0, 5, 1, 1)
        self.verticalLayout.addLayout(self.gridLayout_3)
        self.Input_commands = QtWidgets.QLineEdit(self.gridLayoutWidget)
        self.Input_commands.setMaximumSize(QtCore.QSize(582, 50))
        font = QtGui.QFont()
        font.setPointSize(6)
        font.setBold(True)
        font.setUnderline(False)
        font.setWeight(75)
        font.setStrikeOut(False)
        self.Input_commands.setFont(font)
        self.Input_commands.setStyleSheet("QLineEdit#Input_commands{\n"
"  display: inline-block;\n"
"  color: white;\n"
"  font-weight: 600;\n"
"  text-decoration: none;\n"
"  user-select: none;\n"
"  padding: .5em 2em;\n"
"  outline: none;\n"
"  border: 2px solid;\n"
"  border-radius: 1px;\n"
"  transition: 0.2s;\n"
"} \n"
"\n"
"QLineEdit#Input_commands:hover { background: rgba(255,255,255,.2); }\n"
"QLineEdit#Input_commands:pressed { background: rgb(170, 255, 255); }")
        self.Input_commands.setObjectName("Input_commands")
        self.verticalLayout.addWidget(self.Input_commands)
        self.gridLayout_4.addLayout(self.verticalLayout, 0, 1, 1, 1)
        self.gridLayout.addLayout(self.gridLayout_4, 1, 0, 1, 1)

        self.retranslateUi(Form_view)
        QtCore.QMetaObject.connectSlotsByName(Form_view)

    def retranslateUi(self, Form_view):
        _translate = QtCore.QCoreApplication.translate
        Form_view.setWindowTitle(_translate("Form_view", "Лабораторная работа №1 |Отображение диаграммы"))
        self.Btn_random.setText(_translate("Form_view", "RAND"))
        self.Btn_update.setText(_translate("Form_view", "Обновить"))
        self.Btn_reset.setText(_translate("Form_view", "Сброс"))
        self.label.setText(_translate("Form_view", "f(МК)"))
        self.label_2.setText(_translate("Form_view", "f(СШ)"))
        self.label_3.setText(_translate("Form_view", "F(ОП)"))