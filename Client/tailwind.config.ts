/** @type {import('tailwindcss').Config} */
export default  {
    content: ["./src/**/*.{js,ts,jsx,tsx}"],
    theme: {
      extend: {
        colors: {
          primary: "#1e40af",
          secondary: "#9333ea",
          background: "#f3f4f6",
        },
        fontFamily: {
          sans: ["Inter", "sans-serif"],
        },
      },
    },
    plugins: [],
  };
  