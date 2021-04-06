import json
import os

import numpy as np
from PyQt5 import QtWidgets
from PyQt5.QtWidgets import QMainWindow
from numpy import random

from lab_1.Forms.create_form import Ui_Form_create
from lab_1.Windows.login_Window import login_Window
from lab_1.Windows.view_Window import view_Window
from lab_1.models.command import command as model_command
from lab_1.generate_diagram import generate_render
from lab_1.enums.cache import cache as en_c
from lab_1.enums.type_command import type_command as en_t_cm


class create_Window(QMainWindow):
    def __init__(self, view_Window, parent=None):
        super(create_Window, self).__init__()
        self.ui = Ui_Form_create()
        self.ui.setupUi(self)
        self.view_Window = view_Window
        self.settings = None
        self.command = []
        self.FormRam = int(self.ui.Input_FormOP.cleanText())
        self.FrequencyMC = int(self.ui.Input_FrequencyMP.cleanText())
        self.FrequencySB = int(self.ui.Input_FrequencySB.cleanText())
        self.CountCommands = int(self.ui.Input_CountCommand.cleanText())
        self.chance_of_cache = int(self.ui.Input_Chance.value() * 0.01)
        self.count_commands = int(self.ui.Input_CountCommand.value())
        # Обработчики кнопок
        self.ui.Btn_back.clicked.connect(self.Btn_back_clicked)
        self.ui.Btn_back_to_starter.clicked.connect(self.Btn_back_to_starter_clicked)
        self.ui.Btn_next_to_new_window.clicked.connect(self.Btn_next_to_new_window_clicked)
        self.ui.Btn_next.clicked.connect(self.Btn_next_clicked)
        self.ui.Btn_randFrequencyMP.clicked.connect(self.Btn_randFrequencyMP_clicked)
        self.ui.Btn_randFrequencySB.clicked.connect(self.Btn_randFrequencySB_clicked)
        self.ui.Btn_allRand.clicked.connect(self.Btn_allRand_clicked)
        self.ui.Btn_randChance.clicked.connect(self.Btn_randChance_clicked)
        self.ui.Btn_radomFill.clicked.connect(self.Btn_radomFill_clicked)
        self.ui.Btn_randCountCommand.clicked.connect(self.Btn_randCountCommand_clicked)
        self.ui.Btn_randFormOP.clicked.connect(self.Btn_randFormOP_clicked)
        self.load_settings()
        # TODO: делать правильный запуск установки к заводским настройкам
        self.set_to_default_settings_file()

    def set_to_default_settings_file(
            self,
            path=r"C:\Organization_of_electronic_computers\lab_1\settings.json"
    ):
        try:
            with open(path, "w+") as file:
                data = {
                    'randFrequencyMP': {
                        'min': 3,
                        'max': 9999
                    },
                    'randFrequencySB': {
                        'min': 1,
                    },
                    'randChance': {
                        'min': 1,
                        'max': 99
                    },
                    'randCountCommand': {
                        'min': 2,
                        'max': 30
                    },
                    'randFormOP': {
                        'min': 2,
                        'max': 10
                    }
                }
                json.dump(data, file, indent=4)
        except FileNotFoundError:
            if os.path.exists("C:\Organization_of_electronic_computers"):
                os.mkdir("C:\Organization_of_electronic_computers", 1)
            elif os.path.exists("C:\Organization_of_electronic_computers\lab_1"):
                os.mkdir("C:\Organization_of_electronic_computers\lab_1", 1)
            elif os.path.exists("C:\Organization_of_electronic_computers\lab_1\settings.json"):
                os.open("C:\Organization_of_electronic_computers\lab_1\settings.json", 'w')

    def Start(self):
        self.Btn_back_to_starter_clicked()
        self.show()

    def Btn_back_clicked(self):
        """Вернуться в главное меню"""
        # TODO: Продумать возврат
        # self.hide()

    def Btn_back_to_starter_clicked(self):
        """Вернуться в на 1 фрейм Стартер"""
        Lab_C = int(self.ui.label_CountFill.text())
        if Lab_C == 0:
            self.command = []
            self.ui.frame_second_input.resize(0, 500)
            self.ui.frame_starting_input.resize(800, 500)
        elif Lab_C > 20:
            Lab_C -= 10
            if np.mod(Lab_C, 10) == 0:
                tmp_count = self.command.count()
                for i in range(tmp_count, 10, 1):
                    self.command.pop(i)

            else:
            self.load_to_commands(Lab_C)
            self.set_to_default_values()
            self.CountCommands -= 10
            self.ui.label_CountFill.setText(str(self.CountCommands))
            if Lab_C < 10:
                self.set_enabled_commands(Lab_C)
        elif Lab_C < 10:
            self.load_to_commands(Lab_C)
            self.set_to_default_values()
            self.CountCommands -= Lab_C
            self.ui.label_CountFill.setText(str(self.CountCommands))
            if Lab_C < 10:
                self.set_enabled_commands(Lab_C)
        else:
            print("Error back")

    def Btn_next_to_new_window_clicked(self):
        """Переключиться на другую форму - view_form"""
        Lab_C = int(self.ui.label_CountFill.text())
        In_C = int(self.ui.Input_CountCommand.value())
        if Lab_C == In_C:
            # TODO: Добавить проверку на правильность заносимых данных
            tmp = np.mod(Lab_C, 10)
            if tmp > 0:
                self.save_to_commands(tmp)
            else:
                self.save_to_commands()
            self.view_Window.View_Form(self.save_to_file_and_path())
        elif Lab_C < In_C:
            delta = In_C - Lab_C
            if delta > 10:
                Lab_C += 10
                self.save_to_commands()
                self.set_to_default_values()
                self.ui.label_CountFill.setText(str(Lab_C))
                if delta-10 > 10:
                    self.set_enabled_commands(delta)
                else:
                    self.set_enabled_commands(delta-10)
            else:
                Lab_C += delta
                self.ui.label_CountFill.setText(str(Lab_C))
                self.save_to_commands(delta)
        else:
            self.Btn_next_clicked()
            print("Error btn next window")

    def save_to_commands(self, count=10):
        cm = model_command()
        for i in range(1, count, 1):
            if i == 1:
                cm.__init__(
                    Cache=en_c.CACHE if self.ui.input_cache_1.currentText() == "(КЭШ," else en_c.NO_CACHE,
                    Type_cm=en_t_cm.FM if self.ui.input_object_1.currentText() == "У.О.);" else en_t_cm.MDO,
                    Tacts=int(self.ui.input_tacts_1.value()))
                self.command.append(cm)
            elif i == 2:
                cm.__init__(
                    Cache=en_c.CACHE if self.ui.input_cache_2.currentText() == "(КЭШ," else en_c.NO_CACHE,
                    Type_cm=en_t_cm.FM if self.ui.input_object_2.currentText() == "У.О.);" else en_t_cm.MDO,
                    Tacts=int(self.ui.input_tacts_2.value()))
                self.command.append(cm)
            elif i == 3:
                cm.__init__(
                    Cache=en_c.CACHE if self.ui.input_cache_3.currentText() == "(КЭШ," else en_c.NO_CACHE,
                    Type_cm=en_t_cm.FM if self.ui.input_object_3.currentText() == "У.О.);" else en_t_cm.MDO,
                    Tacts=int(self.ui.input_tacts_3.value()))
                self.command.append(cm)
            elif i == 4:
                cm.__init__(
                    Cache=en_c.CACHE if self.ui.input_cache_4.currentText() == "(КЭШ," else en_c.NO_CACHE,
                    Type_cm=en_t_cm.FM if self.ui.input_object_4.currentText() == "У.О.);" else en_t_cm.MDO,
                    Tacts=int(self.ui.input_tacts_4.value()))
                self.command.append(cm)
            elif i == 5:
                cm.__init__(
                    Cache=en_c.CACHE if self.ui.input_cache_5.currentText() == "(КЭШ," else en_c.NO_CACHE,
                    Type_cm=en_t_cm.FM if self.ui.input_object_5.currentText() == "У.О.);" else en_t_cm.MDO,
                    Tacts=int(self.ui.input_tacts_5.value()))
                self.command.append(cm)
            elif i == 6:
                cm.__init__(
                    Cache=en_c.CACHE if self.ui.input_cache_6.currentText() == "(КЭШ," else en_c.NO_CACHE,
                    Type_cm=en_t_cm.FM if self.ui.input_object_6.currentText() == "У.О.);" else en_t_cm.MDO,
                    Tacts=int(self.ui.input_tacts_6.value()))
                self.command.append(cm)
            elif i == 7:
                cm.__init__(
                    Cache=en_c.CACHE if self.ui.input_cache_7.currentText() == "(КЭШ," else en_c.NO_CACHE,
                    Type_cm=en_t_cm.FM if self.ui.input_object_7.currentText() == "У.О.);" else en_t_cm.MDO,
                    Tacts=int(self.ui.input_tacts_7.value()))
                self.command.append(cm)
            elif i == 8:
                cm.__init__(
                    Cache=en_c.CACHE if self.ui.input_cache_8.currentText() == "(КЭШ," else en_c.NO_CACHE,
                    Type_cm=en_t_cm.FM if self.ui.input_object_8.currentText() == "У.О.);" else en_t_cm.MDO,
                    Tacts=int(self.ui.input_tacts_8.value()))
                self.command.append(cm)
            elif i == 9:
                cm.__init__(
                    Cache=en_c.CACHE if self.ui.input_cache_9.currentText() == "(КЭШ," else en_c.NO_CACHE,
                    Type_cm=en_t_cm.FM if self.ui.input_object_9.currentText() == "У.О.);" else en_t_cm.MDO,
                    Tacts=int(self.ui.input_tacts_9.value()))
                self.command.append(cm)
            elif i == 10:
                cm.__init__(
                    Cache=en_c.CACHE if self.ui.input_cache_10.currentText() == "(КЭШ," else en_c.NO_CACHE,
                    Type_cm=en_t_cm.FM if self.ui.input_object_10.currentText() == "У.О.);" else en_t_cm.MDO,
                    Tacts=int(self.ui.input_tacts_10.value()))
                self.command.append(cm)

    def set_enabled_commands(self, count=10, flag=True):
        self.ui.input_tacts_1.setEnabled(False)
        self.ui.input_tacts_1.setVisible(False)
        self.ui.input_cache_1.setEnabled(False)
        self.ui.input_cache_1.setVisible(False)
        self.ui.input_object_1.setEnabled(False)
        self.ui.input_object_1.setVisible(False)
        self.ui.input_tacts_2.setEnabled(False)
        self.ui.input_tacts_2.setVisible(False)
        self.ui.input_cache_2.setEnabled(False)
        self.ui.input_cache_2.setVisible(False)
        self.ui.input_object_2.setEnabled(False)
        self.ui.input_object_2.setVisible(False)
        self.ui.input_tacts_3.setEnabled(False)
        self.ui.input_tacts_3.setVisible(False)
        self.ui.input_cache_3.setEnabled(False)
        self.ui.input_cache_3.setVisible(False)
        self.ui.input_object_3.setEnabled(False)
        self.ui.input_object_3.setVisible(False)
        self.ui.input_tacts_4.setEnabled(False)
        self.ui.input_tacts_4.setVisible(False)
        self.ui.input_cache_4.setEnabled(False)
        self.ui.input_cache_4.setVisible(False)
        self.ui.input_object_4.setEnabled(False)
        self.ui.input_object_4.setVisible(False)
        self.ui.input_tacts_5.setEnabled(False)
        self.ui.input_tacts_5.setVisible(False)
        self.ui.input_cache_5.setEnabled(False)
        self.ui.input_cache_5.setVisible(False)
        self.ui.input_object_5.setEnabled(False)
        self.ui.input_object_5.setVisible(False)
        self.ui.input_tacts_6.setEnabled(False)
        self.ui.input_tacts_6.setVisible(False)
        self.ui.input_cache_6.setEnabled(False)
        self.ui.input_cache_6.setVisible(False)
        self.ui.input_object_6.setEnabled(False)
        self.ui.input_object_6.setVisible(False)
        self.ui.input_tacts_7.setEnabled(False)
        self.ui.input_tacts_7.setVisible(False)
        self.ui.input_cache_7.setEnabled(False)
        self.ui.input_cache_7.setVisible(False)
        self.ui.input_object_7.setEnabled(False)
        self.ui.input_object_7.setVisible(False)
        self.ui.input_tacts_8.setEnabled(False)
        self.ui.input_tacts_8.setVisible(False)
        self.ui.input_cache_8.setEnabled(False)
        self.ui.input_cache_8.setVisible(False)
        self.ui.input_object_8.setEnabled(False)
        self.ui.input_object_8.setVisible(False)
        self.ui.input_tacts_9.setEnabled(False)
        self.ui.input_tacts_9.setVisible(False)
        self.ui.input_cache_9.setEnabled(False)
        self.ui.input_cache_9.setVisible(False)
        self.ui.input_object_9.setEnabled(False)
        self.ui.input_object_9.setVisible(False)
        self.ui.input_tacts_10.setEnabled(False)
        self.ui.input_tacts_10.setVisible(False)
        self.ui.input_cache_10.setEnabled(False)
        self.ui.input_cache_10.setVisible(False)
        self.ui.input_object_10.setEnabled(False)
        self.ui.input_object_10.setVisible(False)

        for i in range(1, count, 1):
            if i == 1:
                self.ui.input_tacts_1.setEnabled(flag)
                self.ui.input_object_1.setEnabled(flag)
                self.ui.input_cache_1.setEnabled(flag)
                self.ui.input_tacts_1.setVisible(flag)
                self.ui.input_object_1.setVisible(flag)
                self.ui.input_cache_1.setVisible(flag)
            elif i == 2:
                self.ui.input_tacts_1.setEnabled(flag)
                self.ui.input_object_1.setEnabled(flag)
                self.ui.input_cache_1.setEnabled(flag)
                self.ui.input_tacts_1.setVisible(flag)
                self.ui.input_object_1.setVisible(flag)
                self.ui.input_cache_1.setVisible(flag)
            elif i == 3:
                self.ui.input_tacts_1.setEnabled(flag)
                self.ui.input_object_1.setEnabled(flag)
                self.ui.input_cache_1.setEnabled(flag)
                self.ui.input_tacts_1.setVisible(flag)
                self.ui.input_object_1.setVisible(flag)
                self.ui.input_cache_1.setVisible(flag)
            elif i == 4:
                self.ui.input_tacts_1.setEnabled(flag)
                self.ui.input_object_1.setEnabled(flag)
                self.ui.input_cache_1.setEnabled(flag)
                self.ui.input_tacts_1.setVisible(flag)
                self.ui.input_object_1.setVisible(flag)
                self.ui.input_cache_1.setVisible(flag)
            elif i == 5:
                self.ui.input_tacts_1.setEnabled(flag)
                self.ui.input_object_1.setEnabled(flag)
                self.ui.input_cache_1.setEnabled(flag)
                self.ui.input_tacts_1.setVisible(flag)
                self.ui.input_object_1.setVisible(flag)
                self.ui.input_cache_1.setVisible(flag)
            elif i == 6:
                self.ui.input_tacts_1.setEnabled(flag)
                self.ui.input_object_1.setEnabled(flag)
                self.ui.input_cache_1.setEnabled(flag)
                self.ui.input_tacts_1.setVisible(flag)
                self.ui.input_object_1.setVisible(flag)
                self.ui.input_cache_1.setVisible(flag)
            elif i == 7:
                self.ui.input_tacts_1.setEnabled(flag)
                self.ui.input_object_1.setEnabled(flag)
                self.ui.input_cache_1.setEnabled(flag)
                self.ui.input_tacts_1.setVisible(flag)
                self.ui.input_object_1.setVisible(flag)
                self.ui.input_cache_1.setVisible(flag)
            elif i == 8:
                self.ui.input_tacts_1.setEnabled(flag)
                self.ui.input_object_1.setEnabled(flag)
                self.ui.input_cache_1.setEnabled(flag)
                self.ui.input_tacts_1.setVisible(flag)
                self.ui.input_object_1.setVisible(flag)
                self.ui.input_cache_1.setVisible(flag)
            elif i == 9:
                self.ui.input_tacts_1.setEnabled(flag)
                self.ui.input_object_1.setEnabled(flag)
                self.ui.input_cache_1.setEnabled(flag)
                self.ui.input_tacts_1.setVisible(flag)
                self.ui.input_object_1.setVisible(flag)
                self.ui.input_cache_1.setVisible(flag)
            elif i == 10:
                self.ui.input_tacts_1.setEnabled(flag)
                self.ui.input_object_1.setEnabled(flag)
                self.ui.input_cache_1.setEnabled(flag)
                self.ui.input_tacts_1.setVisible(flag)
                self.ui.input_object_1.setVisible(flag)
                self.ui.input_cache_1.setVisible(flag)
        self.update()

    def load_to_commands(self,start, stop, count=10):
        i = 1
        for k in range(start, stop, 1):
            if i == 1:
                self.ui.input_tacts_1.setValue(int(self.command.__getitem__(k).tacts))
                self.ui.input_cache_1.setCurrentText("(КЭШ," if self.command.__getitem__(k).cache == en_c.CACHE else "(Н.К.,")
                self.ui.input_object_1.setCurrentText("У.О.);" if self.command.__getitem__(k).type_command == en_t_cm.FM else "__;")
                i += 1
            elif i == 2:

                i += 1
            elif i == 3:

                i += 1
            elif i == 4:

                i += 1
            elif i == 5:

                i += 1
            elif i == 6:

                i += 1
            elif i == 7:

                i += 1
            elif i == 8:

                i += 1
            elif i == 9:

                i += 1
            elif i == 10:

                i += 1

    def set_to_default_values(self, count=10):
        for i in range(1, count, 1):
            if i == 1:
                self.ui.input_cache_1.setCurrentIndex(1)
                self.ui.input_object_1.setCurrentIndex(1)
                self.ui.input_tacts_1.setValue(1)
            elif i == 2:
                self.ui.input_cache_2.setCurrentIndex(1)
                self.ui.input_object_2.setCurrentIndex(1)
                self.ui.input_tacts_2.setValue(1)
            elif i == 3:
                self.ui.input_cache_3.setCurrentIndex(1)
                self.ui.input_object_3.setCurrentIndex(1)
                self.ui.input_tacts_3.setValue(1)
            elif i == 4:
                self.ui.input_cache_4.setCurrentIndex(1)
                self.ui.input_object_4.setCurrentIndex(1)
                self.ui.input_tacts_4.setValue(1)
            elif i == 5:
                self.ui.input_cache_5.setCurrentIndex(1)
                self.ui.input_object_5.setCurrentIndex(1)
                self.ui.input_tacts_5.setValue(1)
            elif i == 6:
                self.ui.input_cache_6.setCurrentIndex(1)
                self.ui.input_object_6.setCurrentIndex(1)
                self.ui.input_tacts_6.setValue(1)
            elif i == 7:
                self.ui.input_cache_7.setCurrentIndex(1)
                self.ui.input_object_7.setCurrentIndex(1)
                self.ui.input_tacts_7.setValue(1)
            elif i == 8:
                self.ui.input_cache_8.setCurrentIndex(1)
                self.ui.input_object_8.setCurrentIndex(1)
                self.ui.input_tacts_8.setValue(1)
            elif i == 9:
                self.ui.input_cache_9.setCurrentIndex(1)
                self.ui.input_object_9.setCurrentIndex(1)
                self.ui.input_tacts_9.setValue(1)
            elif i == 10:
                self.ui.input_cache_10.setCurrentIndex(1)
                self.ui.input_object_10.setCurrentIndex(1)
                self.ui.input_tacts_10.setValue(1)

    def Btn_next_clicked(self):
        """Переключиться на другой фрейм"""
        In_C = int(self.ui.label_CountFill.text())
        # Показываем нужное кол-во команд
        if In_C > 10:
            self.set_enabled_commands()
        else:
            self.set_enabled_commands(In_C)
        # Обнуляем счётчик
        self.ui.label_CountFill.setText("0")
        # Обнуляем команды
        self.command = []
        # Переклюяаемся на другой фрейм
        self.ui.frame_second_input.resize(800, 500)
        self.ui.frame_starting_input.resize(0, 500)

    def Btn_randFrequencyMP_clicked(self):
        """Изменяем частоту микроконтроллера"""
        if self.FrequencyMC < self.FrequencySB:
            while self.FrequencyMC < self.FrequencySB:
                self.FrequencyMC = random.randint(
                    self.settings['randFrequencyMP']['min'],
                    self.settings['randFrequencyMP']['max']
                )
        else:
            self.FrequencyMC = random.randint(
                self.settings['randFrequencyMP']['min'],
                self.settings['randFrequencyMP']['max']
            )
        self.ui.Input_FrequencyMP.setValue(self.FrequencyMC)

    def Btn_randFrequencySB_clicked(self):
        """Изменяем частоту системной шины"""
        if self.FrequencyMC < self.FrequencySB:
            while self.FrequencyMC < self.FrequencySB:
                self.FrequencySB = int(
                    random.randint(
                        self.settings['randFrequencySB']['min'],
                        self.FrequencyMC
                    )
                )
        else:
            self.FrequencySB = int(
                random.randint(
                    self.settings['randFrequencySB']['min'],
                    self.FrequencyMC
                )
            )
        self.ui.Input_FrequencySB.setValue(int(self.FrequencySB))

    def Btn_allRand_clicked(self):
        """Изменяем все элементы в фреме стартер"""
        self.Btn_randFormOP_clicked()
        self.Btn_randChance_clicked()
        self.Btn_randFrequencySB_clicked()
        self.Btn_randFrequencyMP_clicked()

    def Btn_randChance_clicked(self):
        """Изменяем нас выпадения ни кэша"""
        self.chance_of_cache = random.randint(
            self.settings['randChance']['min'],
            self.settings['randChance']['max']
        ) * 0.01
        self.ui.Input_Chance.setValue(self.chance_of_cache * 100)

    def Btn_radomFill_clicked(self):
        """Заполняем рандомно команды"""
        # TODO: Сделать алгоритм запонения команд
        pass

    def Btn_randCountCommand_clicked(self):
        """Заполняем рандомно кол-во команд"""
        self.CountCommands = random.randint(
            self.settings['randCountCommand']['min'],
            self.settings['randCountCommand']['max']
        )
        self.ui.Input_CountCommand.setValue(self.CountCommands)

    def Btn_randFormOP_clicked(self):
        """Заполняем рандомно форму оперативной памяти"""
        self.FormRam = random.randint(
            self.settings['randFormOP']['min'],
            self.settings['randFormOP']['max']
        )
        self.ui.Input_FormOP.setValue(self.FormRam)

    def save_to_file_and_path(self):
        self.load_settings()
        # TODO: Сделать проверку на правильность
        path_to_save = QtWidgets.QFileDialog.getSaveFileName()[0]
        self.save_to_file(path_to_save)
        return path_to_save

    def load_settings(self):
        try:
            with open("C:\\Organization_of_electronic_computers\\lab_1\\settings.json") as file:
                self.settings = json.load(file)
        except json.decoder.JSONDecodeError:
            pass

    def save_to_file(
            self,
            path_to_save
    ):
        try:
            # TODO: делать проверку на нулевую строку
            with open(path_to_save, "w+") as file:
                data = {
                    "comands": self.command,
                    "FormOP": self.FormRam,
                    "Chance": self.chance_of_cache,
                    "FrequencySB": self.FrequencySB,
                    "FrequencyMC": self.FrequencyMC,
                    "Render": generate_render(self.command, self.FormRam, self.FrequencySB, self.FrequencyMC)
                }
                json.dump(data, file, indent=4)
        except FileNotFoundError:
            # TODO: Добавить проверку
            pass
