/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{astro,html,js,jsx,md,mdx,svelte,ts,tsx,vue}"],
  theme: {
    extend: {
      colors: {
        pri: "#03a9f4",
        accent: "#9aa1ab",
      },
      theme: {
        screens: {
          mobile: "480px",
          // => @media (min-width: 480px) { ... }

          tablet: "640px",
          // => @media (min-width: 640px) { ... }

          desktop: "1024px",
          // => @media (min-width: 1024px) { ... }
        },
      },
    },
  },
  plugins: [],
};
