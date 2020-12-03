#Day 2 Dec 2, 2020 https://adventofcode.com/2020/day/2
from password import Password

def parse(path):
    data = []
    f = open(path, 'r')
    for l in f.readlines():
        data.append(l)
    f.close()
    return data

def organizeData(data):
    passwords = []
    for s in data: 
       l = s.split()
       letter= str.split(l[1], ":")
       policy = str.split(l[0], "-")
       passwords.append(Password(l[2], policy, letter[0]))
    return passwords

# Raw input
item_input = parse("./inputs.txt")

# Create the objects of the data of type Password
passwords = organizeData(item_input)

validPasswords = 0
for p in passwords: 
    if(p.IsValid == True):
        validPasswords += 1

print("Part one is valid: " , validPasswords)

# Part two 

partIIpasswords = 0
for p in passwords: 
    if(p.ValidPartIIPasswords == True): 
        partIIpasswords += 1 

print("Part two is valid: " , partIIpasswords)
