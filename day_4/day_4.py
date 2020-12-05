from passport import Passport

def parse(path):
    f = open(path, 'r')
    fc = f.readlines()
    f.close()
    return fc

def createPassports(singleapp): 
    valid = False
    fieldCount = 0
    cidPresent = False
    for i in singleapp:
       fieldCount += i.count(':') 
       if i.count('cid') > 0:
            cidPresent = True
       if "cid" in i: 
           cidPrent = True
    if(fieldCount == 8): 
       return True
    if(fieldCount < 7): 
        return False
    if(fieldCount == 7 and cidPresent == False): 
        return True
    return valid # All else fails, its invalid
    
def parsePPData(raw_data): 
    totValidPP = 0
    tempPassportData = []
    for i in raw_data:
        if i == '\n':
            ppbool = createPassports(tempPassportData)
            if ppbool == True:
                totValidPP += 1
            tempPassportData = []
        else: 
            tempPassportData.append(i)
    return totValidPP

raw_passports = parse("./input.txt")
print("Total is: ")
print(parsePPData(raw_passports))
