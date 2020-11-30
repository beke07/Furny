export const initComp = () => {
  return {
    ...{
      name: "",
      height: 0,
      width: 0,
      closings: {
        right: false,
        left: false,
        top: false,
        bottom: false,
      },
    },
  };
};
