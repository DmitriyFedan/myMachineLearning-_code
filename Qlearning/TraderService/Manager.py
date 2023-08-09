import time
import random

class Manager:
    


    def __init__(self):
        self._orderCollection = list()
        self._balance = 1000
        self._maxOrders = 5

    def TradeStart(self):
        for i in range(20):
            time.sleep(1)
            print(f"{i} order")
            self._balance += random.randint(-20,20)

    def GetBalance(self):
        return self._balance


