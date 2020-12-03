#Advent of code Day 2

class Password: 

    def __init__(self, password, policy, letter):
        self.password = password
        self.policy = policy
        self.letter = letter
        self.IsValid = False
        self.ValidPartIIPasswords = False
        
        self._cleanLetter()
        self._parsePolicy()
        self._IsPasswordValid()
        self._CheckPartIIValid()

    def _cleanLetter(self):
        self.letter = self.letter[0]

    def _parsePolicy(self): 
        self.smallNumber = self.policy[0]
        self.largeNumber = self.policy[1]

    def _IsPasswordValid(self): 
        validLetterCheck = 0
        for i in self.password: 
            if(i == self.letter): 
                validLetterCheck += 1
        self._CheckValid(validLetterCheck)
    
    def _CheckValid(self, AmountOfLetters):
        if(int(self.smallNumber) <= AmountOfLetters <= int(self.largeNumber)):
            self.IsValid = True

    def _CheckPartIIValid(self):
        posOne = False
        posTwo = False
        try:
            if(self.password[int(self.smallNumber)-1] == self.letter):
                posOne = True
            if(self.password[int(self.largeNumber)-1] == self.letter):
                posTwo = True
            if(posOne == True and posTwo == True):
                self.ValidPartIIPasswords = False
            elif(posOne == True or posTwo == True):
                self.ValidPartIIPasswords = True
            else:
                self.ValidPartIIPasswords = False 
        except: 
            print("Out of bounds probably occured")
