import React, { useState } from "react";

type Props = {};

const MobileNav = (props: Props) => {
  const [menuOpen, setMenuOpen] = useState(false);

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <div className="flex items-center justify-center text-xl mobile:hidden">
      <i onClick={toggleMenu} className="fa-solid fa-bars cursor-pointer"></i>
      <nav
        className={`mobile-menu fixed right-0 top-0 h-full w-1/2 transform bg-white p-6 opacity-95 shadow-md transition-transform duration-300 ease-in-out ${
          menuOpen ? "translate-x-0" : "translate-x-full"
        }`}
      >
        <div className="flex flex-col gap-3 text-right font-bold">
          <a href="/support">Support</a>
          <a href="/blog">Blog</a>
          <a href="/about">About</a>
          <a href="/getstarted">Get started</a>
          <a href="/contact">Contact</a>
        </div>
      </nav>
    </div>
  );
};

export default MobileNav;
