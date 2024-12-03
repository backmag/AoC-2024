
def solve_one():
    
    f = open("input.txt")
    l1 = []
    l2 = []
    for line in f.readlines():
        nbr1, nbr2 = line.split()
        l1.append(nbr1)
        l2.append(nbr2)
    l1.sort()
    l2.sort()

    s = 0
    for i in range(0,len(l1)):
        s += abs(int(l1[i]) - int(l2[i]))

    print(f"The answer is {s}")


def solve_two():
    f = open("input.txt")
    l1 = []
    l2 = []
    for line in f.readlines():
        nbr1, nbr2 = line.split()
        l1.append(nbr1)
        l2.append(nbr2)

    s = 0
    for nbr in l1:
        s += sum([n == nbr for n in l2]) * int(nbr)

    print(f"The answer is {s}!")



solve_two()
