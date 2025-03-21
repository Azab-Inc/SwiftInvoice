/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["**/**"],
  theme: {
    extend: {
      colors: {
            pri: "#1478aa",
            primary: "#1478aa",
        sec: "#03a9f4",
        success: "#28a745",
        warn: "#ffc107",
        danger: "#dc3545",
        accent: "#4f5b6c",
      },
    },
  },
  daisyui: {
    themes: false,
  },
  plugins: [require("daisyui")],
};
