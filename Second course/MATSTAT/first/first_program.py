import math
from scipy.stats import chi2
import statistics
import matplotlib.pyplot as plt
from pandas import *
from scipy.stats import t
from tabulate import tabulate

data = read_csv('vgsales.csv')

numbers = data['Global_Sales'].tolist()

n = len(numbers)

print("Мин x: ", min(numbers))
print("Макс x: ", max(numbers))
print("Кол-во чисел n: ", n)
intervalValue = math.floor(1 + 3.322 * math.log10(n))
print("Число интервалов m: ", intervalValue)
intervalLength = math.ceil((max(numbers) - min(numbers)) / math.floor(intervalValue))
print("Длина интервала k: ", intervalLength)

minX = math.floor(min(numbers))

interval = [[0 for x in range(2)] for y in range(intervalValue)]
for i in range(0, intervalValue):
    interval[i][0] = minX
    interval[i][1] = minX + intervalLength
    minX = minX + intervalLength
print("\nИнтервалы [x, y):")
for i in range(1, len(interval)+1):
    print("{0}-й - {1}".format(i, interval[i-1]))

ni = [0]*intervalValue
for i in range(0, intervalValue):
    x = 0
    for j in range(0, n):
        if interval[i][1] > numbers[j] >= interval[i][0]:
            x = x + 1
    ni[i] = x
# print("\nКол-во элементов ni в интервале:")
# for i in range(0, len(interval)):
#     print("{0} - {1}".format(interval[i], ni[i]))

wi = [0.0]*intervalValue
for i in range(0, intervalValue):
    wi[i] = ni[i] / n
print("\nЧастота w:")
for i in range(0, len(interval)):
    print("{0} - {1}".format(interval[i], wi[i]))

intervalMiddle = [0.0]*intervalValue
for i in range(0, intervalValue):
    intervalMiddle[i] = (interval[i][0] + interval[i][1]) / 2
# print("\nXi срединные:")
# for i in range(0, len(interval)):
#     print("{0} - {1}".format(interval[i], intervalMiddle[i]))

sampleMean = 0
for i in range(0, intervalValue):
    sampleMean = sampleMean + (intervalMiddle[i] * ni[i])
sampleMean = sampleMean / n
print("\nВыборочная средняя Xср = ", round(sampleMean, 2))

difSquare = [0.0]*intervalValue
for i in range(0, intervalValue):
    difSquare[i] = (intervalMiddle[i] - sampleMean) ** 2

sampleVariance = 0.0
for i in range(0, intervalValue):
    sampleVariance = sampleVariance + (difSquare[i] * ni[i])
sampleVariance = sampleVariance / n
print("Выборочная дисперсия \u03C3 = ", round(sampleVariance, 2))


gamma = int(input(f"1 - 0.95;\n2 - 0,99;\n3 - 0.999;\nВыберите надежность: "))
if gamma == 1:
    gamma = 0.95
elif gamma == 2:
    gamma = 0.99
else:
    gamma = 0.999

xIntervalMin = sampleMean - (t.ppf(gamma, n) * math.sqrt(sampleVariance)) / math.sqrt(n)
xIntervalMax = sampleMean + (t.ppf(gamma, n) * math.sqrt(sampleVariance)) / math.sqrt(n)
print("ДИ для генерального среднего\n", round(xIntervalMin, 2), "< Xген <", round(xIntervalMax, 2))


k = n - 1
alpha1 = (1 - gamma) / 2
alpha2 = (1 + gamma) / 2
p1 = 1 - alpha1
p2 = 1 - alpha2
intervalSigma1 = (k * sampleVariance) / chi2.ppf(p1, k)
intervalSigma2 = (k * sampleVariance) / chi2.ppf(p2, k)
print("ДИ для генеральной дисперсии\n", round(intervalSigma1, 2), "< \u03C3ген <", round(intervalSigma2, 2))


median = statistics.median(numbers)
mode = statistics.mode(numbers)
print("Медиана ml = ", median)
print("Мода M0 = ", mode)


difThree = [0.0] * intervalValue
for i in range(0, intervalValue):
    difThree[i] = (difSquare[i]) ** 1.5
m3 = 0
for i in range(0, intervalValue):
    m3 = m3 + difThree[i] * ni[i]
m3 = m3 / n
a3 = m3 / (sampleVariance ** 1.5)
print("Ассиметрия A3 = ", round(a3, 2))


difFour = [0.0] * intervalValue
for i in range(0, intervalValue):
    difFour[i] = (difSquare[i]) ** 2
m4 = 0
for i in range(0, intervalValue):
    m4 = m4 + difFour[i] * ni[i]
m4 = m4 / n
ek = m4 / (sampleVariance ** 2) - 3
print("Эксцесс Ek = ", round(ek, 2))


plt.hist(numbers, edgecolor='black', bins=intervalValue)
plt.title('Гистограмма для ' + str(n) + ' элементов')
plt.xlabel('Значения')
plt.ylabel('Частоты')
plt.show()


fig, ax = plt.subplots(1, 1)
tableData = [[] for y in range(0, intervalValue)]
for i in range(0, intervalValue):
    tableData[i] = [ni[i], intervalMiddle[i], round(difSquare[i], 2)]

column_labels = ["ni", "Хiсер", "(Хiсер - Хср)^2"]
k = DataFrame(tableData, columns=column_labels)
ax.axis('tight')
ax.axis('off')
ax.table(cellText=k.values, colLabels=k.columns, rowLabels=interval,
         loc='center')
plt.show()


# col_names = ["Интервалы", "ni", "Xiсер", "(Хiсер - Хср)^2"]
# print(tabulate(tableData, headers=col_names, tablefmt="fancy_grid"))
