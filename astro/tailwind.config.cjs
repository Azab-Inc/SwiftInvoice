/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{astro,html,js,jsx,md,mdx,svelte,ts,tsx,vue}"],
  theme: {
    extend: {
      colors: {
        pri: "#1478aa",
        sec: "#03a9f4",
        accent: "#9aa1ab",
        windows: "#00aff0",
        mac: "#424242",
        ios: "#12b6fa",
        android: "#2edf85",
      },
      screens: {
        mobile: "560px",

        tablet: "780px",

        desktop: "1024px",
      },
    },
  },
  plugins: [require("tailwind-scrollbar")],
};
