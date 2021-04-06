from enum import Enum


class type_command(Enum):
    """"Тип команды"""
    MDO = 1  # Modeling Dynamic Object              - Моделирование динамического объекта
    MSO = 1  # Modeling System Object               - Моделирование Системного объекта
    DCP = 1  # Dispatching a computational object   - Диспетчеризация Вычислительного Объекта
    _ = 1  # Обобщённый вид первых трёх комманд
    FM = 2  # Facility management                   - Управление объектом
