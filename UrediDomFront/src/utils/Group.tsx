export const groupBy = (list: any[], key: string) => {
  return list.reduce((newList: any[], element) => {
    (newList[element[key]] = newList[element[key]] || []).push(element);
    return newList;
  }, {});
}