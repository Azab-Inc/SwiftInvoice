/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{astro,html,js,jsx,md,mdx,svelte,ts,tsx,vue}"],
  theme: {
    extend: {
      colors: {
        pri: "#1478aa",
        accent: "#9aa1ab",
      },
      screens: {
        mobile: "480px",

        tablet: "780px",

        desktop: "1024px",
      },
    },
  },
  plugins: [],
};
