from lab_1.enums.cache import cache
from lab_1.enums.type_command import type_command


class command:
    def __init__(self, Cache=cache.CACHE, Type_cm=type_command.FM, Tacts=1):
        self.cache = Cache
        self.type_command = Type_cm
        self.tacts = Tacts
