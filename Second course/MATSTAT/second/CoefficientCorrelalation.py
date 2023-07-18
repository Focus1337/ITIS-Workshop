import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns
from sklearn.linear_model import LinearRegression

sns.set()
salaryData = pd.read_csv('Salary_Data.csv')

x = np.array(salaryData['YearsExperience'].tolist())
y = np.array(salaryData['Salary'].tolist())

np.corrcoef(x, y)

data = {'x': x, 'y': y}
df = pd.DataFrame(data)
print(df)

df.describe()
print(df.describe())

df['x'].median()
print(df['x'].median())

df['x'].std()
print(df['x'].std())

pair_grid_plot = sns.PairGrid(df)
pair_grid_plot.map(plt.scatter)

# Распределение x и y
sns.jointplot(x='x', y='y', data=df)

sns.histplot(x=df['x'], kde=True)

sns.histplot(x=df['y'], kde=True)

# Корреляция
corr = df.corr()
f, ax = plt.subplots(figsize=(9, 6))
sns.heatmap(corr, annot=True, linewidths=1.5, fmt='.6f', ax=ax)
plt.show()

x = df.iloc[:, :-1].values
y = df.iloc[:, -1].values

print(x)

print(y)

regressor = LinearRegression()
regressor.fit(x, y)
print(regressor.fit(x, y))


print(regressor.coef_)

print(regressor.intercept_)

yDomik = (regressor.coef_ * df.x.max() + 2) - regressor.intercept_
print('yDomik: {0}'.format(yDomik))

'Уравнение регрессии y = ax + b \n'
'y = {0}x - {1}'.format(regressor.coef_, regressor.intercept_)
'где a=coef_, b=intercept_, x - независимая переменная, y - зависимая переменная'

# Прогноз
regressor.predict([[8]])
print(regressor.predict([[8]]))

# Прогноз x_max + 2
regressor.predict([[df.x.max() + 2]])
print(regressor.predict([[df.x.max() + 2]]))

plt.scatter(x, y, color='red')
plt.plot(x, regressor.predict(x), color='blue')
plt.title('Regression')
plt.xlabel('x')
plt.ylabel('y')
plt.show()
